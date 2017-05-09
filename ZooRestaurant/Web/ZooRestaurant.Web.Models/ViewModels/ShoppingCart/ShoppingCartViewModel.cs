namespace ZooRestaurant.Web.Models.ViewModels.ShoppingCart
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class ShoppingCartViewModel : IMapFrom<ShoppingCart>
    {
        public string Id { get; set; }

        public string CustomerId { get; set; }
        
        public IEnumerable<CartViewModel> Carts { get; set; }
    }
}