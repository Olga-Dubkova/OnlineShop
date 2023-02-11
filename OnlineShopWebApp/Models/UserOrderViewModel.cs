using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserOrderViewModel
    {
		[Required(ErrorMessage = "Не указано Имя")]
		[StringLength(25, MinimumLength = 2, ErrorMessage = "Имя от 2 до 25 символов")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Не указана Фамилия")]
		[StringLength(25, MinimumLength = 2, ErrorMessage = "Имя от 2 до 25 символов")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Не указан Телефон")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Не указан Адрес")]
		[StringLength(100, MinimumLength = 10, ErrorMessage = "Адрес от 10 до 100 символов")]
		public string Address { get; set; }
    }
}
