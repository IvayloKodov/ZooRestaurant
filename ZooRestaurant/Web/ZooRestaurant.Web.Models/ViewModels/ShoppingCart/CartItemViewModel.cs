namespace ZooRestaurant.Web.Models.ViewModels.ShoppingCart
{
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class CartItemViewModel : IMapFrom<Cart>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public int ImageId { get; set; }
    }
}