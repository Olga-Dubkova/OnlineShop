using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Interfases
{
    public interface IProductStore
    {
        List<ProductModel> GetAll();
        ProductModel TryGetById(Guid id);

        void Add (ProductModel newProduct);

        void Remove(Guid id);

        void Update(ProductModel product);
	}
}
