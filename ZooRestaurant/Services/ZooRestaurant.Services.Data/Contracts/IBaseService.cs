namespace ZooRestaurant.Services.Data.Contracts
{
    using System.Linq;

    public interface IBaseService<T> where T : class
    {
        void Add(T item);

        void Delete(object id);

        IQueryable<T> GetAll();

        T GetById(object id);

        void Dispose();

        void Save();
    }
}