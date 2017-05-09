namespace ZooRestaurant.Services.Data
{
    using AutoMapper;
    using Base;
    using Contracts;
    using Web.Models.ViewModels.Profile;
    using ZooRestaurant.Data.Common.Repositories;
    using ZooRestaurant.Data.Models;

    public class ProfileService : BaseService<User>, IProfileService
    {
        private readonly IImagesService images;
        private readonly IUsersService users;

        public ProfileService(IRepository<User> dataSet,
                              IImagesService images,
                              IUsersService users)
            : base(dataSet)
        {
            this.images = images;
            this.users = users;
        }

        public void Update(EditProfileViewModel profile)
        {
            var userDb = this.users.GetById(profile.Id);

            this.Mapper.Map(userDb, profile);

            var image = this.images.GetImageFromHttpFileBase(profile.ProfileImage);

            if (image != null)
            {
                userDb.Images.Add(image);
            }

            this.users.Save();
        }
    }
}