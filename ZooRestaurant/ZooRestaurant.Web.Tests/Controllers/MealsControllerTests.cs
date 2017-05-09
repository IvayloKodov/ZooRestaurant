namespace ZooRestaurant.Web.Tests.Controllers
{
    using System.Net;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Contracts;
    using Models.ViewModels.Meals;
    using Moq;
    using TestStack.FluentMVCTesting;
    using Web.Controllers;
    using ZooRestaurant.Services.Data.Contracts;

    [TestClass]
    public class MealsControllerTests
    {
        [TestInitialize]
        public void TestInit()
        {
            AutoMapperConfig.Initialize(typeof(IMapping).Assembly);
        }

        [TestMethod]
        public void DetailsByIdShouldReturnCorrectViewAndModel()
        {
            var mealsServiceMock = new Mock<IMealsService>();

            const string mealName = "Салата Цезар";

            mealsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Meal()
                {
                    Name = mealName,
                    Category = new MealCategory() { Name = "Салати" }
                });

            var controller = new MealsController(mealsServiceMock.Object,null);

            controller.WithCallTo(x => x.Details(123123))
                      .ShouldRenderView("Details")
                      .WithModel<MealDetailsViewModel>(
                        viewModel =>
                        {
                            Assert.AreEqual(mealName, viewModel.Name);
                        }
                     )
                     .AndNoModelErrors();
        }

        [TestMethod]
        public void DetailsByIdShouldTReturnNotFound()
        {
            var mealsServiceMock = new Mock<IMealsService>();
            Meal meal = null;

            mealsServiceMock.Setup(x => x.GetById(0))
                .Returns(meal);

            var controller = new MealsController(mealsServiceMock.Object,null);

            controller.WithCallTo(x => x.Details(0))
                .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }
    }
}