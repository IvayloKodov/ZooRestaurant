namespace ZooRestaurant.Web.Tests.Controllers
{
    using System.Linq;
    using System.Net;
    using Data.Common.Repositories;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Contracts;
    using Moq;
    using TestStack.FluentMVCTesting;
    using Web.Controllers;
    using ZooRestaurant.Services.Data;
    using ZooRestaurant.Services.Data.Contracts;

    [TestClass]
    public class ShoppingCartControllerTests
    {

        [TestInitialize]
        public void TestInit()
        {
            AutoMapperConfig.Initialize(typeof(IMapping).Assembly);
        }
        
        [TestMethod]
        public void SuccessfulAdd_Should_Redirect()
        {
            var shoppingCartService = new Mock<IShoppingCartService>();
            shoppingCartService.Setup(s => s.Add(It.IsAny<int>())).Returns(true);
            var controller = new ShoppingCartController(shoppingCartService.Object);

            controller.WithCallTo(c => c.Add(It.IsAny<int>()))
                .ShouldRedirectTo<MenuController>(typeof(MenuController).GetMethod("Dishes"));
        }

        [TestMethod]
        public void NullAdd_Should_StatusCodeNotFound()
        {
            var mealsRepository = new Mock<IRepository<Meal>>();
            mealsRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(It.IsAny<Meal>());

            var shoppingCartService = new Mock<IShoppingCartService>();

            var controller = new ShoppingCartController(shoppingCartService.Object);

            controller.WithCallTo(c => c.Add(It.IsAny<int>()))
                .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }
    }
}