using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfases
{
    public interface IFavotiteRepository
    {
        void Add(string userId, ProductModel product);
        void Remove(string userId, Guid productId);
        void Clear(string userId);
        List<ProductModel> GetAll(string userId);
    }
}
