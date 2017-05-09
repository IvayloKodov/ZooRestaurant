namespace ZooRestaurant.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Attributes;
    using Infrastructure.Mapping.Extensions;
    using Models.ViewModels.Users;
    using Services.Data.Contracts;
    using Web.Controllers.Base;
    using Data.Models;

    [MyAuthorize(Roles = "Admin")]
    public class MembersController : BaseController
    {
        private readonly IUsersService members;

        public MembersController(IUsersService members)
        {
            this.members = members;
        }

        // Admin/Members
        [HttpGet]
        [Route("Admin/Members")]
        public ActionResult Index()
        {
            var usersVms = this.members
                               .GetAll()
                               .To<UserViewModel>()
                               .ToList();

            return this.View(usersVms);
        }

        // Admin/Members/Details/5
        [HttpGet]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = this.members.GetById(id);

            if (user == null)
            {
                return this.HttpNotFound();
            }

            var userVm = this.Mapper.Map<UserViewModel>(user);
            return this.View(userVm);
        }

        // Admin/Members/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            User user = this.members.GetById(id);

            if (id == null || user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var rolesListItems = this.members.GetAllUserRoles(user);

            var userVm = this.Mapper.Map<UserEditViewModel>(user);
            userVm.Roles = rolesListItems;

            return this.View(userVm);
        }

        // POST: Admin/Members/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEditViewModel model)
        {
            var userDb = this.members.GetById(model.Id);

            if (this.ModelState.IsValid && userDb != null)
            {
                this.Mapper.Map(model, userDb);
                this.members.Save();
            }

            return this.View("Details", this.Mapper.Map<UserViewModel>(userDb));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.members.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
