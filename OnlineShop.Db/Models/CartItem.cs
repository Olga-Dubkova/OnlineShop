namespace OnlineShop.Db.Models
{
	public class CartItem
	{
		public Guid Id { get; set; }

		public ProductModel Product { get; set; }

		public CartModel Cart { get; set; }	

		public int Amount { get; set; }
	}
}
