namespace ZooRestaurant.Web.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Base;
    using Data.Models;
    using Models.ViewModels.Meals;
    using Services.Data.Contracts;

    [RoutePrefix("Meals")]
    public class MealsController : BaseController
    {
        private readonly IMealsService meals;
        private readonly IImagesService images;

        public MealsController(IMealsService meals,
                               IImagesService images)
        {
            this.meals = meals;
            this.images = images;
        }

        [HttpGet]
        [Route("Add")]
        public ActionResult Add()
        {
            var categories = this.meals.Categories();
            var addMealVm = new AddMealViewModel() { Categories = new SelectList(categories, "Id", "Name") };

            return this.View(addMealVm);
        }

        [HttpPost]
        [Route("Add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddMealViewModel mealVm)
        {
            if (this.ModelState.IsValid)
            {
                var meal = this.Mapper.Map<Meal>(mealVm);
                meal.Image = this.images.GetImageFromHttpFileBase(mealVm.Image);
                this.meals.Add(meal);
                this.meals.Save();

                return this.RedirectToAction("Details", new { id = meal.Id });
            }

            return this.View(mealVm);
        }

        [HttpGet]
        [Route("{id:int}/Details")]
        public ActionResult Details(int id)
        {
            var meal = this.meals.GetById(id);

            if (meal == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var mealVm = this.Mapper.Map<MealDetailsViewModel>(meal);

            return this.View(mealVm);
        }
    }
}