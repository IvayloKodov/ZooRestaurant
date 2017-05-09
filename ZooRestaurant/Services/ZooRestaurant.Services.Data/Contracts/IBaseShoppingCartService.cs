namespace ZooRestaurant.Services.Data.Contracts
{
    using System.Linq;
    using ZooRestaurant.Data.Models;

    public interface IBaseShoppingCartService
    {
        ShoppingCart ShoppingCart { get; }

        bool Add(int mealId);

        void Remove(int id);
        
        IQueryable<Cart> GetAll();

        Cart GetById(int id);

        void Save();
    }
}