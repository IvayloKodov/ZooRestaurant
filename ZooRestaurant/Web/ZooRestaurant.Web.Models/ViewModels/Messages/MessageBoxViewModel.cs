namespace ZooRestaurant.Web.Models.ViewModels.Messages
{
    using System.Collections.Generic;

    public class MessageBoxViewModel
    {
        public IEnumerable<MessagePartViewModel> UnreadedMessages { get; set; }

        public IEnumerable<MessagePartViewModel> ReadedMessages { get; set; }
    }
}