namespace ZooRestaurant.Web.Controllers
{
    using System.Web.Mvc;
    using Base;
    using Data.Models;
    using Models.ViewModels.Messages;
    using Services.Data.Contracts;

    public class HomeController : BaseController
    {
        private readonly IMessagesService messages;

        public HomeController(IMessagesService messages)
        {
            this.messages = messages;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

        [HttpPost]
        [Route("Home/SendMessage")]
        [ValidateAntiForgeryToken]
        public ActionResult SendMessage(MessageViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var message = this.Mapper.Map<Message>(model);
                this.messages.Add(message);
                this.messages.Save();
            }

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delivery()
        {
            return this.View();
        }
    }
}