using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [EmailAddress(ErrorMessage = "Введите валидный email")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 25 символов")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
