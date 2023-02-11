using System;

namespace OnlineShopWebApp.Models
{
    public class FavoriteViewModel
    {
        public Guid Id { get; }    
        public string UserId { get; } 
        public ProductViewModel ProductViewModel { get; set; }

    }
}
