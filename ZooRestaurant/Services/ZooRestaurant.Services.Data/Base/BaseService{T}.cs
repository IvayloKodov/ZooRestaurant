namespace ZooRestaurant.Services.Data.Base
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Web.Infrastructure.Mapping;
    using ZooRestaurant.Data.Common.Repositories;

    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        protected BaseService(IRepository<T> dataSet)
        {
            this.Data = dataSet;
        }

        protected IRepository<T> Data { get; set; }

        public virtual void Add(T item)
        {
            this.Data.Add(item);
            this.Data.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            var entity = this.Data.GetById(id);
            if (entity == null)
            {
                throw new InvalidOperationException("No entity with provided id found.");
            }

            this.Data.Delete(entity);
            this.Data.SaveChanges();
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.Data.All();
        }

        public virtual T GetById(object id)
        {
            return this.Data.GetById(id);
        }


        public void Dispose()
        {
            this.Data.Dispose();
        }

        public virtual void Save()
        {
            this.Data.SaveChanges();
        }

        public IMapper Mapper => AutoMapperConfig.Configuration.CreateMapper();
    }
}
