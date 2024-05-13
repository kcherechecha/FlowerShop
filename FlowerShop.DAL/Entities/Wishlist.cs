namespace FlowerShop.DAL.Entities
{
    public class Wishlist
    {
        public Guid UserId { get; set; }
        public virtual ICollection<ItemWishlist>? ItemWishlists { get; set; }
    }
}