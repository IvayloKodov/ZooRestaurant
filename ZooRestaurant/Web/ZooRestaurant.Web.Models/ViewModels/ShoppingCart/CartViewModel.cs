namespace ZooRestaurant.Web.Models.ViewModels.ShoppingCart
{
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class CartViewModel : IMapFrom<Cart>
    {
        public int Id { get; set; }

        public int MealId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public int ImageId { get; set; }
    }
}