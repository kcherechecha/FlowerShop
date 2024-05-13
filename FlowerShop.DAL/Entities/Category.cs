namespace FlowerShop.DAL.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Item>? Items { get; set; }
    }
}
