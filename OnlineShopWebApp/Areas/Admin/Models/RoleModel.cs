using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class RoleModel
    {
        [Required(ErrorMessage = "Не указана роль")]
        public string Name { get; set; }
    }
}
