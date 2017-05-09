namespace ZooRestaurant.Web.Models.ViewModels.Meals
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class MealViewModel : IMapFrom<Meal>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual IEnumerable<Image> Images { get; set; }
    }
}