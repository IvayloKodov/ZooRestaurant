namespace ZooRestaurant.Web.Models.ViewModels.Users
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class UserEditViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public UserEditViewModel()
        {
            this.Roles = new List<SelectListItem>();
        }

        public string Id { get; set; }

        [Required]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Поща")]
        public string Email { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        public string[] RoleId { get; set; }

        [Display(Name = "Роли")]
        public IEnumerable<SelectListItem> Roles { get; set; }

        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<UserEditViewModel, User>()
                .ForMember(u => u.Roles,
                    opts => opts.MapFrom(uvm => uvm.RoleId
                        .Select(r => new IdentityUserRole()
                        {
                            RoleId = r,
                            UserId = uvm.Id
                        })));

            configuration.CreateMap<User, UserEditViewModel>()
            .ForMember(uvm => uvm.RoleId, opts => opts.Ignore())
            .ForMember(uvm => uvm.Roles, opts => opts.Ignore());
        }
    }
}