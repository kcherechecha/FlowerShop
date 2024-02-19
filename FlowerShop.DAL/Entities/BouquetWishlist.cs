public class BouquetWishlist
{
    public Guid BouquetId {get; set;}
    public Guid WishlistId {get; set;}
    public Bouquet? Bouquet {get; set;}
    public Wishlist? Wishlist {get; set;}
}