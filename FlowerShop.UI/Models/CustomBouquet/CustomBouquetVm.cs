namespace FlowerShop.UI.Models.CustomBouquet
{
    public class CustomBouquetVm
    {
        public Guid Id { get; set; }
        public byte[] Photo
        {
            set => PhotoFile = Convert.ToBase64String(value);
        }
        public string? PhotoFile { get; set; }
        public Guid UserId { get; set; }
        public string? UserDescription { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
