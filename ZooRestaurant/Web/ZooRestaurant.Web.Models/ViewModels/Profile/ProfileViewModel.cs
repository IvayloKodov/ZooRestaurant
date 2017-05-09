namespace ZooRestaurant.Web.Models.ViewModels.Profile
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class ProfileViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        public int ImageId { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Поща")]
        public string Email { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, ProfileViewModel>()
                .ForMember(p => p.ImageId,
                    opts => opts.MapFrom(x => x.Images.LastOrDefault() != null ? x.Images.Last().Id : 0));
        }
    }
}