namespace FlowerShop.DAL.Entities
{
    public class ItemWishlist
    {
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public Wishlist? Wishlist { get; set;}
        public Item? Item { get; set; }
    }
}
