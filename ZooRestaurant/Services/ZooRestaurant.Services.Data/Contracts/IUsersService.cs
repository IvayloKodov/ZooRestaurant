namespace ZooRestaurant.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ZooRestaurant.Data.Models;

    public interface IUsersService : IBaseService<User>
    {
        IEnumerable<SelectListItem> GetAllUserRoles(User user);
    }
}