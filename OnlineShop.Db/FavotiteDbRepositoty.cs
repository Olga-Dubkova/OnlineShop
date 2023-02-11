using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfases;
using OnlineShop.Db.Models;
using System.Linq;

namespace OnlineShop.Db
{
    public class FavotiteDbRepositoty : IFavotiteRepository
    {

        private readonly DatabaseContext databaseContext;

        public FavotiteDbRepositoty(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(string userId, ProductModel product)
        {
            var existingFavorite = databaseContext.Favorites.FirstOrDefault(x => x.UserId == userId && x.ProductModel.Id == product.Id);
            if (existingFavorite == null)
            {
                databaseContext.Favorites.Add(new FavoriteModel
                {
                    ProductModel= product,
                    UserId = userId
                });
                databaseContext.SaveChanges();
            }            
        }

        public void Clear (string userId)
        {
            var userFavoriteProducts = databaseContext.Favorites.Where(u => u.UserId == userId).ToList();
            databaseContext.Favorites.RemoveRange(userFavoriteProducts);    
            databaseContext.SaveChanges();  
        }

        public List<ProductModel> GetAll(string userId) 
        {
            return databaseContext.Favorites.Where(x=> x.UserId == userId)
                .Include(x => x.ProductModel)
                .Select(x => x.ProductModel)
                .ToList();
        }

        public void Remove(string UserId, Guid productId)
        {
            var existingFavorite = databaseContext.Favorites.FirstOrDefault(x => x.UserId == UserId && x.ProductModel.Id == productId);

            if (existingFavorite != null)   
            databaseContext.Favorites.Remove(existingFavorite);
            databaseContext.SaveChanges();  

        }
    }
}
