namespace ZooRestaurant.Services.Data.Contracts
{
    using System.Web;
    using ZooRestaurant.Data.Models;

    public interface IImagesService : IBaseService<Image>
    {
        Image GetDefaultImage();

        Image GetImageFromHttpFileBase(HttpPostedFileBase file);
    }
}