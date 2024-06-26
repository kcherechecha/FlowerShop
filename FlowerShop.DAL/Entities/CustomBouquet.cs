namespace FlowerShop.DAL.Entities
{
    public class CustomBouquet
    {
        public Guid Id { get; set; }
        public byte[]? Photo { get; set; }
        public Guid UserId { get; set; }
        public string? UserDescription { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RequestTime { get; set; }
    }
}