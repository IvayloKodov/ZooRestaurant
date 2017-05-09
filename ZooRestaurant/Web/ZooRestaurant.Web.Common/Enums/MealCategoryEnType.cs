namespace ZooRestaurant.Web.Common.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum MealCategoryEnType
    {
        [Display(Name = "Салати")]
        Salads = 0,

        [Display(Name = "Предястия")]
        Starters = 1,

        [Display(Name = "Пилешки ястия")]
        ChickenDishes = 2,

        [Display(Name = "Рибни ястия")]
        FishDishes = 3,

        [Display(Name = "Свински ястия")]
        PorkDishes = 4,

        [Display(Name = "Телешки ястия")]
        BeafDishes = 5,

        [Display(Name = "Гарнитури")]
        Garnitures = 6,

        [Display(Name = "Десерти")]
        Desserts = 7,

        [Display(Name = "Сосове")]
        Sauces = 8
    }
}