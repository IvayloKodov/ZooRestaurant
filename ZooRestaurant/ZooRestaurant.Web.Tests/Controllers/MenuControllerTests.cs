namespace ZooRestaurant.Web.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.Enums;
    using Common.Helpers;
    using Repositories;
    using Infrastructure.Mapping;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Contracts;
    using Models.ViewModels.Meals;
    using Moq;
    using TestStack.FluentMVCTesting;
    using Web.Controllers;
    using ZooRestaurant.Services.Data.Contracts;

    [TestClass]
    public class MenuControllerTests
    {
        [TestInitialize]
        public void TestInit()
        {
            AutoMapperConfig.Initialize(typeof(IMapping).Assembly);
        }

        [TestMethod]
        public void DishesByCategoryShouldReturnRightViewAndModel()
        {
            //Arrange
            string mealCategory = MealCategoryEnType.Salads.GetDisplayName();

            var mealsService = new Mock<IMealsService>();
            mealsService.Setup(s => s.MealsByCategory(It.IsAny<string>()))
                        .Returns(
                            Repositories
                            .GetMealsRepository()
                            .All()
                            .Where(m => m.Category.Name == mealCategory)
                        );

            var controller = new MenuController(mealsService.Object);

            //Act Assert
            controller.WithCallTo(c => c.Dishes(It.IsAny<string>(), 1))
                           .ShouldRenderView("Index")
                           .WithModel<IEnumerable<MealViewModel>>()
                           .AndNoModelErrors();
        }

        [TestMethod]
        public void SearchShouldReturnRightViewAndModels()
        {
            //Arrange
            var mealsService = new Mock<IMealsService>();
            mealsService.Setup(s => s.MealsByCategory(It.IsAny<string>()))
                        .Returns(Repositories.GetMealsRepository().All);

            const string query = "Цезар";
            var controller = new MenuController(mealsService.Object);

            //Act Assert
            controller
                .WithCallTo(c => c.Search(query,1))
                .ShouldRenderPartialView("_MealsResults")
                .WithModel<IEnumerable<MealViewModel>>(
                    models =>
                    {
                        foreach (var model in models)
                        {
                            Assert.IsTrue(model.Name.ToLower().Contains(query.ToLower()));
                        }
                    }
                )
                .AndNoModelErrors();
        }
    }
}