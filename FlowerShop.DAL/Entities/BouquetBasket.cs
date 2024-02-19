public class BouquetBasket
{
    public Guid BasketId {get; set;}
    public Guid BouquetId {get; set;}
    public Basket? Basket {get; set;}
    public Bouquet? Bouquet {get; set;}
}