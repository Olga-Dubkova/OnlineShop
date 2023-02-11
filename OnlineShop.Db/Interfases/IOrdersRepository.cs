using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfases
{
    public interface IOrdersRepository
    {
        void Add(OrderModel order);
        List<OrderModel> GetAll();
        OrderModel TryGetById(Guid id);
        void UpdateStatus(Guid id, OrderStatus newStatus);
    }
}