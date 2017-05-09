namespace ZooRestaurant.Web.Areas.Admin.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Attributes;
    using Models.ViewModels.Messages;
    using Services.Data.Contracts;
    using Web.Controllers.Base;
    using System.Linq;
    using Infrastructure.Mapping.Extensions;

    [MyAuthorize(Roles = "Admin, Dispatcher")]
    public class MessagesController : BaseController
    {
        private readonly IMessagesService messages;

        public MessagesController(IMessagesService messages)
        {
            this.messages = messages;
        }

        [HttpGet]
        [Route("Admin/Messages")]
        public ActionResult Inbox()
        {
            var readedMessages = this.messages
                                     .GetAll()
                                     .Where(m => m.IsRead)
                                     .To<MessagePartViewModel>()
                                     .ToList();

            var unReadedMessages = this.messages
                                       .GetAll()
                                       .Where(m => !m.IsRead)
                                       .To<MessagePartViewModel>()
                                       .ToList();

            var messagesBox = new MessageBoxViewModel { ReadedMessages = readedMessages, UnreadedMessages = unReadedMessages };

            return this.View(messagesBox);
        }

        [HttpGet]
        [Route("Admin/Messages/Read/{id}")]
        public ActionResult Read(int id)
        {
            var message = this.messages.GetById(id);
            if (message == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            message.IsRead = true;
            this.messages.Save();

            var messageVm = this.Mapper.Map<MessageViewModel>(message);

            return this.View(messageVm);
        }

        [ChildActionOnly]
        public int MessagesCount()
        {
            return this.messages
                       .GetAll()
                       .Count(m => !m.IsRead);
        }
    }
}