namespace OnlineShop.Db.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public UserOrderModel User { get; set; }
        public List<CartItem> Items { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDataTime { get; set; }
        public OrderModel()
        {
            Status = OrderStatus.Created;
            CreateDataTime = DateTime.Now;
        }
    }
}
