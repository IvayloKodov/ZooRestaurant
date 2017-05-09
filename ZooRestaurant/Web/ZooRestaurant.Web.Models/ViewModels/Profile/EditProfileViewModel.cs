namespace ZooRestaurant.Web.Models.ViewModels.Profile
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class EditProfileViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public EditProfileViewModel()
        {
            this.Neighborhoods = new List<SelectListItem>();
        }

        public string Id { get; set; }

        [Required]
        [Display(Name = "Име")]
        [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "{0}тo трябва да бъде дълга {2} символа!", MinimumLength = ValidationConstants.MinNameLength)]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "{0}та трябва да бъде дълга {2} символа!", MinimumLength = ValidationConstants.UsernameMinLength)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(ValidationConstants.UsernameMaxLength, ErrorMessage = "Името трябва да бъде дълга {2} символа!", MinimumLength = ValidationConstants.UsernameMinLength)]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Телефон")]
        [RegularExpression(@"(^08[789]\d{7}$)|(^\+3598[789]\d{7}$)", ErrorMessage = "Грешен телефон!")]
        public string Phone { get; set; }

        public int TownId { get; set; }

        [Display(Name = "Град")]
        public IEnumerable<SelectListItem> Towns { get; set; }

        public int NeighborhoodId { get; set; }

        [Display(Name = "Квартал")]
        public IEnumerable<SelectListItem> Neighborhoods { get; set; }

        [Required]
        [Display(Name = "Адрес")]
        [StringLength(100, ErrorMessage = "Адресът не може да е по-дълъг от 100 символа")]
        public string AdditionalAddress { get; set; }

        [Display(Name = "Коментар")]
        public string Comment { get; set; }

        [Display(Name = "Снимка")]
        public HttpPostedFileBase ProfileImage { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, EditProfileViewModel>()
                .ForMember(u => u.ProfileImage, opts => opts.Ignore())
                .ForMember(u => u.AdditionalAddress, opts => opts.MapFrom(u => u.Address))
                .ForMember(u => u.Phone, opts => opts.MapFrom(u => u.PhoneNumber))
                .ReverseMap();
        }
    }
}