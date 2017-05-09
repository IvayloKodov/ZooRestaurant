namespace ZooRestaurant.Web.Models.ViewModels.Meals
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class MealDetailsViewModel : IMapFrom<Meal>
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Грамаж")]
        public int Weight { get; set; }

        [Display(Name = "Съдържание")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        public virtual IEnumerable<Image> Images { get; set; }
    }
}