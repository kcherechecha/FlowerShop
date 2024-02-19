public class Basket
{
    public Guid Id {get; set;}
    public Guid UserId {get; set;}
    public virtual ICollection<BouquetBasket>? BouquetBaskets {get; set;}
    public Order? Order {get; set;}
}