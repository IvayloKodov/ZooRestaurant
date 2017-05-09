namespace ZooRestaurant.Web.Models.ViewModels.Meals
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class AddMealViewModel : IMapFrom<Meal>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Грамаж")]
        public int Weight { get; set; }

        [Display(Name = "Съдържание")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Категория")]
        public IEnumerable<SelectListItem> Categories { get; set; }

        [Display(Name = "Снимка")]
        public HttpPostedFileBase Image { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Meal, AddMealViewModel>()
                         .ReverseMap()
                         .ForMember(x => x.Image, opts => opts.Ignore());
        }
    }
}