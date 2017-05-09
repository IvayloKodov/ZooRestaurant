namespace ZooRestaurant.Services.Data.Contracts
{
    using ZooRestaurant.Data.Models;

    public interface IShoppingCartService : IBaseShoppingCartService
    {
        void ChangeQuantity(int id, string operation);

        void MakeOrder(Customer customer);

        bool IsEmptyShoppingCart();
    }
}