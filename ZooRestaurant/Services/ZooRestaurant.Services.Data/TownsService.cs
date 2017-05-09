namespace ZooRestaurant.Services.Data
{
    using System;
    using System.Linq;
    using Base;
    using Contracts;
    using ZooRestaurant.Data.Common.Repositories;
    using ZooRestaurant.Data.Models.AddressModels;

    public class TownsService : BaseService<Town>, ITownsService
    {
        public TownsService(IRepository<Town> dataSet)
            : base(dataSet)
        {
        }

        public IQueryable<Neighborhood> GetTownNeigborhoods(int townId)
        {
            var town = this.GetAll().FirstOrDefault(t => t.Id == townId);

            if (town == null)
            {
                throw new InvalidOperationException("There is no such TownId!");
            }

            return town.Neighborhoods.AsQueryable();
        }
    }
}