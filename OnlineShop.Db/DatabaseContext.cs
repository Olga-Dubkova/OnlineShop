using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options)
		{
			Database.Migrate();
		}

		public DbSet<ProductModel> Products { get; set; }

		public DbSet<CartModel> Carts { get; set; }

        public DbSet<FavoriteModel> Favorites { get; set; }

		public DbSet<OrderModel> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().HasData(new List<ProductModel>()
			{
				new ProductModel(Guid.NewGuid(),"Ноутбук 1", 50000, "Тут будет описание", "/images/laptop1.jpg"),
                new ProductModel(Guid.NewGuid(),"Ноутбук 2", 88000, "Тут будет описание", "/images/laptop2.jpg"),
                new ProductModel(Guid.NewGuid(),"Ноутбук 3", 95000, "Тут будет описание", "/images/laptop3.jpg"),
                new ProductModel(Guid.NewGuid(),"Телефон 1", 76000, "Тут будет описание", "/images/phone1.jpg"),
                new ProductModel(Guid.NewGuid(),"Телефон 2", 40000, "Тут будет описание", "/images/phone2.jpg"),
                new ProductModel(Guid.NewGuid(),"Телефон 3", 57000, "Тут будет описание", "/images/phone3.jpg"),
                new ProductModel(Guid.NewGuid(),"Планшет 1", 58000, "Тут будет описание", "/images/tablet1.jpg"),
                new ProductModel(Guid.NewGuid(),"Планшет 2", 87000, "Тут будет описание", "/images/tablet2.jpg"),
                new ProductModel(Guid.NewGuid(),"Планшет 3", 87000, "Тут будет описание", "/images/tablet3.jpg")
            });
        }
    }
}
