namespace ZooRestaurant.Services.Data.Contracts
{
    using System.Linq;
    using ZooRestaurant.Data.Models.AddressModels;

    public interface ITownsService : IBaseService<Town>
    {
        IQueryable<Neighborhood> GetTownNeigborhoods(int townId);
    }
}