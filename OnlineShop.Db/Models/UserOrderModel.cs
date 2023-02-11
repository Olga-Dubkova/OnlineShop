using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class UserOrderModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public string Surname { get; set; }


        public string Phone { get; set; }


        public string Address { get; set; }
    }
}
