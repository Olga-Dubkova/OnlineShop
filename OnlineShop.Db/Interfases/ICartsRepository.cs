using OnlineShop.Db.Models;
using System;

namespace OnlineShop.Db.Interfases
{
	public interface ICartsRepository
	{
		void Add(ProductModel product, string userId);
		void Clear(string userId);
		void Decrease(Guid productId, string userId);
		CartModel TryGetByUserId(string userId);
	}
}
