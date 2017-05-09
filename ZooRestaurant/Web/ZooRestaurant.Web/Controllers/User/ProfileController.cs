namespace ZooRestaurant.Web.Controllers.User
{
    using System.Linq;
    using System.Web.Mvc;
    using Base;
    using Microsoft.AspNet.Identity;
    using Models.ViewModels.Profile;
    using Services.Data.Contracts;

    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly IUsersService users;
        private readonly ITownsService towns;
        private readonly IProfileService profile;

        public ProfileController(IUsersService users,
                                 ITownsService towns,
                                 IProfileService profile)
        {
            this.users = users;
            this.towns = towns;
            this.profile = profile;
        }

        // GET: Profile
        [Route("Profile")]
        public ActionResult Index()
        {
            var currentUser = this.users.GetById(this.User.Identity.GetUserId());
            var profileVm = this.Mapper.Map<ProfileViewModel>(currentUser);

            return this.View("Profile", profileVm);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var userDb = this.users.GetById(this.User.Identity.GetUserId());
            var editRegisterVm = this.Mapper.Map<EditProfileViewModel>(userDb);
            var userTownId = userDb.Address.Neighborhood.TownId;
            var townsItems = new SelectList(this.towns.GetAll().ToList(), "Id", "Name");
            townsItems.First(t => t.Value == userTownId.ToString()).Selected = true;
            editRegisterVm.Towns = townsItems;
            var neighborhoodsItems = new SelectList(this.towns.GetTownNeigborhoods(userTownId).ToList(), "Id", "Name");
            neighborhoodsItems.First(n => n.Value == userDb.Address.NeighborhoodId.ToString()).Selected = true;
            editRegisterVm.Neighborhoods = neighborhoodsItems;

            return this.PartialView("_EditPartialView", editRegisterVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProfileViewModel profile)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("_EditPartialView", profile);
            }
            this.profile.Update(profile);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ProfilePage()
        {
            var currentUser = this.users.GetById(this.User.Identity.GetUserId());
            var profileVm = this.Mapper.Map<ProfileViewModel>(currentUser);

            return this.PartialView("_ProfilePartialView", profileVm);
        }
    }
}