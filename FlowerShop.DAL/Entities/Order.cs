public class Order
{
    public Guid OrderId {get; set;}
    public string? OrderAddress {get; set;}
    public DateTime OrderTime {get; set;} = DateTime.Now;
    public Guid UserId {get; set;}
    public Guid BasketId {get; set;}
    public int OrderStatusId {get; set;}
    public OrderStatus? OrderStatus {get; set;}
    public Basket? Basket {get; set;}
}