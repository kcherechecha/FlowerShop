using FlowerShop.UI.Common.Extensions;

namespace FlowerShop.UI.Models
{
    public class ItemListVm
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public byte[] Photo
        {
            set => PhotoFile = Convert.ToBase64String(value);
        }
        public string? PhotoFile { get; set; }

        public decimal Price { get; set; }
    }
}
