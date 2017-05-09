namespace ZooRestaurant.Web.Models.ViewModels.Address
{
    using Data.Models.AddressModels;
    using Infrastructure.Mapping.Contracts;

    public class NeighborhoodViewModel : IMapFrom<Neighborhood> 
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}