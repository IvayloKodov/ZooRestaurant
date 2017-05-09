namespace ZooRestaurant.Web.Tests.Controllers
{
    using System.IO;
    using System.Net.Mime;
    using System.Text;
    using System.Web.Mvc;
    using Data.Common.Repositories;
    using Data.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TestStack.FluentMVCTesting;
    using Web.Controllers;
    using ZooRestaurant.Services.Data.Contracts;

    [TestClass]
    public class ImagesControllerTests
    {
        [TestMethod]
        public void GetImageByIdShouldReturnContent()
        {
            byte[] content = { 129, 130, 131 };

            var repositoryMock = new Mock<IImagesService>();
            repositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Image()
                {
                    FileExtension = "png",
                    Content = content
                });

            var controller = new ImagesController(repositoryMock.Object);
            var action = controller.WithCallTo(c => c.GetImage(It.IsAny<int>())).ActionResult as FileContentResult;

            Assert.AreEqual(content,action.FileContents);
            Assert.AreEqual("image/png",action.ContentType);
        }
    }
}