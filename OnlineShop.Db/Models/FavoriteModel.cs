using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class FavoriteModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public ProductModel ProductModel { get; set; }

    }
}
