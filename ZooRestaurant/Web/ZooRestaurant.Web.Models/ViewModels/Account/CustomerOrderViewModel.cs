namespace ZooRestaurant.Web.Models.ViewModels.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Address;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;
    using ShoppingCart;

    public class CustomerOrderViewModel : IMapFrom<Customer>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Коментар")]
        public string Comment { get; set; }

        [Display(Name = "Адрес")]
        public AddressViewModel Address { get; set; }

        [Display(Name = "Покупки")]
        public IEnumerable<CartViewModel> Carts { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Customer, CustomerOrderViewModel>()
                .ForMember(cvm => cvm.FirstName, opts => opts.MapFrom(c => c.User.FirstName))
                .ForMember(cvm => cvm.LastName, opts => opts.MapFrom(c => c.User.LastName))
                .ForMember(cvm => cvm.PhoneNumber, opts => opts.MapFrom(c => c.User.PhoneNumber))
                .ForMember(cvm => cvm.Carts, opts => opts.MapFrom(c => c.ShoppingCart.Carts))
                .ForMember(cvm => cvm.Address, opts => opts.MapFrom(c => c.User.Address));
        }
    }
}