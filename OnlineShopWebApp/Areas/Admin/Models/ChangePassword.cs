using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ChangePassword
    {

        [Required(ErrorMessage = "Не указан логин")]
        [EmailAddress(ErrorMessage = "Введите валидный email")]
        public string Login { get; set; }

		public string Name { get; set; }

		[Required(ErrorMessage = "Не указан телефон")]
		public string Phone { get; set; }   

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 25 символов")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
