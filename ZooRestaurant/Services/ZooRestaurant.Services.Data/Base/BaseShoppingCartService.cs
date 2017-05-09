namespace ZooRestaurant.Services.Data.Base
{
    using System;
    using System.Linq;
    using System.Web;
    using Contracts;
    using Microsoft.AspNet.Identity;
    using ZooRestaurant.Data.Common.Repositories;
    using ZooRestaurant.Data.Models;

    public abstract class BaseShoppingCartService : IBaseShoppingCartService
    {
        private readonly IRepository<ShoppingCart> shoppingCarts;
        private readonly IRepository<Cart> carts;
        private readonly IRepository<Meal> meals;

        protected BaseShoppingCartService(IRepository<ShoppingCart> shoppingCarts,
                                          IRepository<Cart> carts,
                                          IRepository<Meal> meals)
        {
            this.carts = carts;
            this.shoppingCarts = shoppingCarts;
            this.meals = meals;
        }

        public ShoppingCart ShoppingCart
        {
            get
            {
                var currentUserId = HttpContext.Current.User.Identity.GetUserId();

                return this.shoppingCarts
                           .All()
                           .First(s => s.Customer.User.Id == currentUserId);
            }
        }


        public bool Add(int mealId)
        {
            var meal = this.meals.GetById(mealId);
            if (meal == null)
            {
                return false;
            }

            var sameMealInCart = this.GetAll().FirstOrDefault(c => c.Name == meal.Name);

            if (sameMealInCart == null)
            {
                this.ShoppingCart.Carts.Add(new Cart()
                {
                    Name = meal.Name,
                    ImageId = meal.Image.Id,
                    Price = meal.Price,
                    Quantity = 1,
                    MealId = meal.Id
                });
            }
            else
            {
                sameMealInCart.Quantity++;
            }

            this.Save();
            return true;
        }

        public void Remove(int id)
        {
            var cart = this.GetById(id);
            if (cart == null)
            {
                throw new InvalidOperationException("There is no such cart Id!");
            }
            this.ShoppingCart.Carts.Remove(cart);
            this.carts.Delete(cart);

            this.Save();
        }

        public IQueryable<Cart> GetAll()
        {
            return this.ShoppingCart
                       .Carts
                       .AsQueryable();
        }

        public Cart GetById(int id)
        {
            return this.ShoppingCart
                       .Carts
                       .FirstOrDefault(c => c.Id == id);
        }

        public void Save()
        {
            this.shoppingCarts.SaveChanges();
        }
    }
}