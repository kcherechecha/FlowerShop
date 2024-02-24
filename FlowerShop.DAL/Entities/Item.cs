namespace FlowerShop.DAL.Entities;

public class Item
{
    public Guid Id { get; set; }
    public Guid ItemId { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
}