namespace ZooRestaurant.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Web.Common.Constants;

    public class Meal
    {
        [Key]
        [ForeignKey("Image")]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.MaxMealNameLength)]
        public string Name { get; set; }

        public int Weight { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public virtual MealCategory Category { get; set; }

        public virtual Image Image { get; set; }
    }
}