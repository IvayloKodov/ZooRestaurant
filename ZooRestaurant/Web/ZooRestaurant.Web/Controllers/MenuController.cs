namespace ZooRestaurant.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Base;
    using Common.Constants;
    using Extensions;
    using Infrastructure.Mapping.Extensions;
    using Models.ViewModels.Meals;
    using PagedList;
    using Services.Data.Contracts;

    [RoutePrefix("Menu")]
    public class MenuController : BaseController
    {
        private readonly IMealsService _meals;

        public MenuController(IMealsService meals)
        {
            this._meals = meals;
        }

        [HttpGet]
        [Route("Dishes/{category?}")]
        public ActionResult Dishes(string category, int page = 1)
        {
            var mealsVm = this._meals
                              .MealsByCategory(category)
                              .To<MealViewModel>()
                              .OrderBy(m => m.Price)
                              .ToPagedList(page, ViewConstants.MaxMealsPerPage);

            return this.View("Index", mealsVm);
        }

        [HttpPost]
        [Route("Search")]
        public ActionResult Search(string query, int page = 1)
        {
            var result = this._meals
                .GetAll()
                .Search(query)
                .To<MealViewModel>()
                .OrderBy(m => m.Name)
                .ToPagedList(page, ViewConstants.MaxMealsPerPage);

            return this.PartialView("_MealsResults", result);
        }
    }
}