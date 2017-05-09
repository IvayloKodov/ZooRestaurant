namespace ZooRestaurant.Services.Data
{
    using System;
    using System.Linq;
    using Base;
    using Contracts;
    using Web.Common.Enums;
    using Web.Common.Helpers;
    using ZooRestaurant.Data.Common.Repositories;
    using ZooRestaurant.Data.Models;

    public class MealsService : BaseService<Meal>, IMealsService
    {
        private readonly IRepository<MealCategory> categories;

        public MealsService(IRepository<Meal> dataSet,
                            IRepository<MealCategory> categories)
            : base(dataSet)
        {
            this.categories = categories;
        }

        public IQueryable<Meal> MealsByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return this.GetAll();
            }

            if (Enum.IsDefined(typeof(MealCategoryEnType), category))
            {
                category = ((MealCategoryEnType)Enum.Parse(typeof(MealCategoryEnType), category)).GetDisplayName();
                return this.GetAll().Where(m => m.Category.Name == category);
            }

            return this.GetAll();
        }

        public IQueryable<MealCategory> Categories()
        {
            return this.categories.All();
        }
    }
}