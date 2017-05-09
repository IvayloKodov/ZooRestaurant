namespace ZooRestaurant.Services.Data
{
    using Base;
    using Contracts;
    using ZooRestaurant.Data.Common.Repositories;
    using ZooRestaurant.Data.Models;

    public class MessagesService : BaseService<Message>, IMessagesService
    {
        public MessagesService(IRepository<Message> dataSet) 
            : base(dataSet)
        {
        }
    }
}