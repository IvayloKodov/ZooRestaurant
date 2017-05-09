namespace ZooRestaurant.Web.Models.ViewModels.Address
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models.AddressModels;
    using Infrastructure.Mapping.Contracts;

    public class AddressViewModel : IMapFrom<Address>, IHaveCustomMappings
    {
        [Display(Name = "Град")]
        public string Town { get; set; }

        [Display(Name = "Квартал")]
        public string Neighborhood { get; set; }

        [Display(Name = "Адрес")]
        public string AdditionalAddress { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Address, AddressViewModel>()
                .ForMember(avm => avm.Neighborhood, opts => opts.MapFrom(a => a.Neighborhood.Name))
                .ForMember(avm => avm.Town, opts => opts.MapFrom(a => a.Neighborhood.Town.Name));
        }
    }
}