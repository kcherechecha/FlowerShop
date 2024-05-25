namespace FlowerShop.UI.Models.Item;

public class InputItemModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public IFormFile PhotoFile { get; set; }
    public byte[]? Photo { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
}