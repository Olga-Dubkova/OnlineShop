using OnlineShop.Db.Models;
using OnlineShop.Db.Interfases;
using OnlineShop.Db;

namespace OnlineShopWebApp.Db
{
    public class ProductDbStore : IProductStore
    {
        private readonly DatabaseContext databaseContext;

        public ProductDbStore(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<ProductModel> GetAll()
        {
            return databaseContext.Products.ToList();
        }
        //private List<ProductModel> MakeProduct()
        //{
        //    var products = new List<ProductModel>
        //    {
        //        new ProductModel("Ноутбук 1", 50000, "Тут будет описание", "/images/laptop1.jpg"),
        //        new ProductModel("Ноутбук 2", 88000, "Тут будет описание", "/images/laptop2.jpg"),
        //        new ProductModel("Ноутбук 3", 95000, "Тут будет описание", "/images/laptop3.jpg"),
        //        new ProductModel("Телефон 1", 76000, "Тут будет описание", "/images/phone1.jpg"),
        //        new ProductModel("Телефон 2", 40000, "Тут будет описание", "/images/phone2.jpg"),
        //        new ProductModel("Телефон 3", 57000, "Тут будет описание", "/images/phone3.jpg"),
        //        new ProductModel("Планшет 1", 58000, "Тут будет описание", "/images/tablet1.jpg"),
        //        new ProductModel("Планшет 2", 87000, "Тут будет описание", "/images/tablet2.jpg")
        //    };
        //    SaveProduct(products);
        //    return products;
        //}
        public ProductModel TryGetById(Guid id)
        {
            var products = GetAll();

            return products.FirstOrDefault(product => product.Id == id);

        }

        public void Add(ProductModel newProduct)
        {
            newProduct.ImagePath = "/images/laptop1.jpg";
            databaseContext.Products.Add(newProduct);
            databaseContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var products = GetAll();

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == id)
                {
                    products.RemoveAt(i);
                }
            }
            databaseContext.SaveChanges();
        }

        public void Update(ProductModel product)
        {
            var updateProduct = TryGetById(product.Id);
            {

                updateProduct.Name = product.Name;
                updateProduct.Description = product.Description;
                updateProduct.Cost = product.Cost;

            };

            databaseContext.SaveChanges();

        }
    }
}
