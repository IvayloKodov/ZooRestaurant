namespace ZooRestaurant.Services.Data.Contracts
{
    using System.Linq;
    using ZooRestaurant.Data.Models;

    public interface IMealsService : IBaseService<Meal>
    {
        IQueryable<Meal> MealsByCategory(string category);

        IQueryable<MealCategory> Categories();
    }
}