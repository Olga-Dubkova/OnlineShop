using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
	public class UserAccount
	{
		public UserAccount()
		{
		}

		[Required(ErrorMessage = "Не указан логин")]
		[EmailAddress(ErrorMessage = "Введите валидный email")]
		public string Login { get; set; }
		
		public string Password { get; set; }

		[Required(ErrorMessage = "Не указан телефон")]
		public string Phone { get; set; }	

		public string Name { get; set; }
		
	
	}
}
