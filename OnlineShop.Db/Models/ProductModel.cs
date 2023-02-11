using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class ProductModel
    {
		public ProductModel()
		{
			CartItems= new List<CartItem>();	
		}

        public ProductModel(Guid id, string name, decimal cost, string description, string imagePath)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagePath;
        }

        public Guid Id { get; set; }

		public string Name { get; set; }

		public decimal Cost { get; set; }

		public string Description { get; set; }

		public string ImagePath { get; set; }

		public List<CartItem> CartItems { get; set; }
	}
}
