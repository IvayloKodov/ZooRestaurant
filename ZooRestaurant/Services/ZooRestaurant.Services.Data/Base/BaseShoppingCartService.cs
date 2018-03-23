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
        private readonly IRepository<ShoppingCart> _shoppingCarts;
        private readonly IRepository<CartItem> _carts;
        private readonly IRepository<Meal> _meals;

        protected BaseShoppingCartService(IRepository<ShoppingCart> shoppingCarts,
                                          IRepository<CartItem> carts,
                                          IRepository<Meal> meals)
        {
            this._carts = carts;
            this._shoppingCarts = shoppingCarts;
            this._meals = meals;
        }

        public ShoppingCart ShoppingCart
        {
            get
            {
                var currentUserId = HttpContext.Current.User.Identity.GetUserId();

                return this._shoppingCarts
                           .All()
                           .First(s => s.Customer.User.Id == currentUserId);
            }
        }


        public bool Add(int mealId)
        {
            var meal = this._meals.GetById(mealId);
            if (meal == null)
            {
                return false;
            }

            var sameMealInCart = this.GetAll().FirstOrDefault(c => c.Name == meal.Name);

            if (sameMealInCart == null)
            {
                this.ShoppingCart.Carts.Add(new CartItem()
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
            this._carts.Delete(cart);

            this.Save();
        }

        public IQueryable<CartItem> GetAll()
        {
            return this.ShoppingCart
                       .Carts
                       .AsQueryable();
        }

        public CartItem GetById(int id)
        {
            return this.ShoppingCart
                       .Carts
                       .FirstOrDefault(c => c.Id == id);
        }

        public void Save()
        {
            this._shoppingCarts.SaveChanges();
        }
    }
}