public class Wishlist
{
    public Guid Id {get; set;}
    public Guid UserId {get; set;}
    public virtual ICollection<BouquetWishlist>? BouquetWishlists {get; set;}
}