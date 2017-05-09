namespace ZooRestaurant.Services.Data.Contracts
{
    using Web.Models.ViewModels.Profile;
    using ZooRestaurant.Data.Models;

    public interface IProfileService : IBaseService<User>
    {
        void Update(EditProfileViewModel profile);
    }
}