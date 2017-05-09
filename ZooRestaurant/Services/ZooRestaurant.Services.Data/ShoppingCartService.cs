namespace ZooRestaurant.Services.Data
{
    using System;
    using System.Linq;
    using System.Web;
    using Base;
    using Contracts;
    using ZooRestaurant.Data.Common.Repositories;
    using ZooRestaurant.Data.Models;

    public class ShoppingCartService : BaseShoppingCartService, IShoppingCartService
    {
        private readonly IRepository<Order> orders;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCarts,
                                   IRepository<Cart> carts,
                                   IRepository<Meal> meals,
                                   IRepository<Order> orders)
            : base(shoppingCarts, carts,meals)
        {
            this.orders = orders;
        }

        public ShoppingCart GetCart => this.ShoppingCart;

        public void ChangeQuantity(int id, string operation)
        {
            var cart = this.GetById(id);
            if (cart == null)
            {
                throw new HttpException(404, "Cart not found!");
            }

            if (operation == "plus")
            {
                cart.Quantity++;
            }
            else if (operation == "minus")
            {
                if (cart.Quantity - 1 > 0)
                {
                    cart.Quantity--;
                }
                else
                {
                    this.Remove(cart.Id);
                }
            }

            this.Save();
        }

        public void MakeOrder(Customer customer)
        {
            var order = new Order()
            {
                Customer = customer,
                OrderDate = DateTime.Now,
                Address = customer.User.Address.ToString(),
                DeliveryTax = 2,
                OrdersDetails = customer
                                        .ShoppingCart
                                        .Carts
                                        .Select(c => new OrderDetails()
                                        {
                                            MealId = c.MealId,
                                            Quantity = c.Quantity
                                        })
                                        .ToList(),
                TotalPrice = customer.ShoppingCart.Carts.Sum(c => c.TotalPrice)
            };

            this.orders.Add(order);
            this.orders.SaveChanges();

            this.CleanShoppingCart(customer.ShoppingCart);
        }

        private void CleanShoppingCart(ShoppingCart customerShoppingCart)
        {
            var cartsIds = customerShoppingCart
                                            .Carts
                                            .Select(c => c.Id)
                                            .ToList();

            foreach (var cartId in cartsIds)
            {
                this.Remove(cartId);
            }
        }

        public bool IsEmptyShoppingCart()
        {
            return !this.ShoppingCart.Carts.Any();
        }
    }
}