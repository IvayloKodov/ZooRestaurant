namespace ZooRestaurant.Web.Controllers.Base
{
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        protected IMapper Mapper => AutoMapperConfig.Configuration.CreateMapper();
    }
}