namespace ZooRestaurant.Web.Tests.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.Enums;
    using Common.Helpers;
    using Data.Common.Repositories;
    using Data.Models;
    using Moq;

    public static class Repositories
    {
        public static IRepository<Image> GetImagesRepository()
        {
            var repository = new Mock<IRepository<Image>>();
            repository.Setup(r => r.All()).Returns(() => new List<Image>
            {
                new Image()
                {
                    FileExtension = "png",
                    Content = new byte[] {129, 130, 131}
                },
                new Image()
                {
                    FileExtension = "png",
                    Content = new byte[] {166, 166, 166}
                },new Image()
                {
                    FileExtension = "png",
                    Content = new byte[] {177, 177, 177}
                }
            }.AsQueryable());

            return repository.Object;
        }

        public static IRepository<Meal> GetMealsRepository()
        {
            var repository = new Mock<IRepository<Meal>>();
            repository.Setup(r => r.All()).Returns(() => new List<Meal>
            {
                new Meal()
                {
                    Name = "Салата с ягоди",
                    Category = new MealCategory() {Name = MealCategoryEnType.Salads.GetDisplayName()}
                },
                new Meal()
                {
                    Name = "Салата Цезар",
                    Category = new MealCategory() {Name = MealCategoryEnType.Salads.GetDisplayName()}
                },
                 new Meal()
                {
                    Name = "Цезар зелена салата",
                    Category = new MealCategory() {Name = MealCategoryEnType.Salads.GetDisplayName()}
                },
                new Meal()
                {
                    Name = "Свинско с картофи",
                    Category = new MealCategory() {Name = MealCategoryEnType.PorkDishes.GetDisplayName()}
                },
                new Meal()
                {
                    Name = "Свинско",
                    Category = new MealCategory() {Name = MealCategoryEnType.PorkDishes.GetDisplayName()}
                },
                new Meal()
                {
                    Name = "Пилешко",
                    Category = new MealCategory() {Name = MealCategoryEnType.ChickenDishes.GetDisplayName()}
                },
                new Meal()
                {
                    Name = "Таратор",
                    Category = new MealCategory() {Name = MealCategoryEnType.Starters.GetDisplayName()}
                },
                new Meal()
                {
                    Name = "Торта",
                    Category = new MealCategory() {Name = MealCategoryEnType.Desserts.GetDisplayName()}
                },
                new Meal()
                {
                    Name = "Риба",
                    Category = new MealCategory() {Name = MealCategoryEnType.FishDishes.GetDisplayName()}
                }
            }.AsQueryable());

            return repository.Object;
        }
    }
}