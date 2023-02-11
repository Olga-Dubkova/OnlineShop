using OnlineShop.Db.Interfases;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopWebApp.Common
{
	public class OrdersDbRepository : IOrdersRepository
    {
		private readonly DatabaseContext databaseContext;

        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(OrderModel order)
        {
			databaseContext.Orders.Add(order);
            databaseContext.SaveChanges();
        }

		public List<OrderModel> GetAll()
		{
			return databaseContext.Orders.Include(x => x.User)  
				.Include(x => x.Items)
				.ThenInclude(x => x.Product)
				.ToList();
        }

		public OrderModel TryGetById(Guid id)
		{
			var order = databaseContext.Orders.Include(x => x.User)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id == id);
			return order;

            //return databaseContext.Orders.FirstOrDefault(x=> x.Id == id);
        }

		public void UpdateStatus(Guid id, OrderStatus newStatus)
		{
			var order = TryGetById(id);
			if (order != null)
			{ 
				order.Status = newStatus;	
			}
			databaseContext.SaveChanges();	
		}
	}
}
