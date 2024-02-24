public class Bouquet
{
    public Guid Id {get; set;}
    public string? Name {get; set;}
    public byte[]? Photo {get; set;}
    public decimal Price {get; set;}
    public virtual ICollection<FlowerBouquet>? FlowerBouquets {get; set;}
    public virtual ICollection<BouquetWishlist>? BouquetWishlists { get; set; }
}