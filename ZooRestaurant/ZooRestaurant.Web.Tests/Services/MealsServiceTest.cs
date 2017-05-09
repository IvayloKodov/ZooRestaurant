namespace ZooRestaurant.Web.Tests.Services
{
    using Common.Enums;
    using Common.Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ZooRestaurant.Services.Data;
    using ZooRestaurant.Services.Data.Contracts;
    using Repositories;

    [TestClass]
    public class MealsServiceTest
    {
        private IMealsService service;

        [TestInitialize]
        public void Init()
        { 
            this.service = new MealsService(Repositories.GetMealsRepository(),null);
        }

        //[TestMethod]
        //public void MealsByCategoryShouldReturnCorrectly()
        //{
        //    var categoryName = MealCategoryEnType.Salads.GetDisplayName();

        //    var meals = this.service
        //                    .MealsByCategory(categoryName);

        //    foreach (var meal in meals)
        //    {
        //        Assert.AreEqual(categoryName, meal.Category.Name);
        //    }
        //}
    }
}