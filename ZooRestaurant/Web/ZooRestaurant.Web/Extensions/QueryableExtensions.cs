namespace ZooRestaurant.Web.Extensions
{
    using System.Linq;
    using Data.Models;

    public static class QueryableExtensions
    {
        //Meals Search
        public static IQueryable<Meal> Search(this IQueryable<Meal> collection, string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return collection;
            }

            return collection.Where(m => m.Name.ToLower().Contains(query.ToLower()));
        }
    }
}