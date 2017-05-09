namespace ZooRestaurant.Services.Data
{
    using Base;
    using Contracts;
    using ZooRestaurant.Data.Common.Repositories;
    using ZooRestaurant.Data.Models;

    public class CustomersService : BaseService<Customer>, ICustomersService
    {
        public CustomersService(IRepository<Customer> dataSet) 
            : base(dataSet)
        {
        }


    }
}