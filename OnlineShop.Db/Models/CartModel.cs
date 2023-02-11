using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db.Models
{
	public class CartModel
	{
		public CartModel()
		{
			Items= new List<CartItem>();
		}

		public Guid Id { get; set; }

		public string UserId { get; set; }

		public List<CartItem> Items { get; set; }	


	}
}
