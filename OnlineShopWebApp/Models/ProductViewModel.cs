using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {

        public Guid Id { get; set; }

		[Required(ErrorMessage = "Не указано название товара")]
		[StringLength(25, MinimumLength = 2, ErrorMessage = "Наименование от 2 до 25 символов")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Не указана цена товара")]
		public decimal Cost { get; set; }

		[Required(ErrorMessage = "Не указано описание товара")]
		[StringLength(150, MinimumLength = 5, ErrorMessage = "Наименование от 5 до 150 символов")]
		public string Description { get; set; }

        public string ImagePath { get; set; }   

	}
}
