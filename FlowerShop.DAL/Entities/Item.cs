namespace FlowerShop.DAL.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Photo { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public virtual ICollection<ItemWishlist>? ItemWishlists { get; set; }
        public virtual ICollection<ItemOrder>? ItemOrders { get; set; }
    }
}