namespace ZooRestaurant.Web.Models.ViewModels.ShoppingCart
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;
    using ValidationAttributes;

    public class ShoppingCartViewModel : IMapFrom<ShoppingCart>
    {
        public string Id { get; set; }

        public string CustomerId { get; set; }

        [CartSize(ErrorMessage = "Трябва да има поне една покупка!")]
        public IEnumerable<CartViewModel> Carts { get; set; }
    }
}