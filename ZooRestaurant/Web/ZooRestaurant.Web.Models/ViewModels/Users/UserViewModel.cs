namespace ZooRestaurant.Web.Models.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }
        
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Поща")]
        public string Email { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }
    }
}