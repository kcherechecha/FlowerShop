namespace FlowerShop.DAL.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string? OrderAddress { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime OrderTime { get; set; }
        public Guid UserId { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public virtual ICollection<ItemOrder>? ItemOrders { get; set; }

    }
}