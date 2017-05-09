namespace ZooRestaurant.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Web.Common.Constants;

    public class MealCategory
    {
        private ICollection<Meal> meals;

        public MealCategory()
        {
            this.meals = new HashSet<Meal>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(ValidationConstants.MaxLengthCategoryName)]
        public string Name { get; set; }

        public virtual ICollection<Meal> Meals
        {
            get { return this.meals; }
            set { this.meals = value; }
        }
    }
}