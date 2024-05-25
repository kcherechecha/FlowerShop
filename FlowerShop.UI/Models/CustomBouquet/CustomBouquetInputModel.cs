using System.ComponentModel.DataAnnotations;
using FlowerShop.UI.Common.Extensions;

namespace FlowerShop.UI.Models.CustomBouquet
{
    public class CustomBouquetInputModel
    {
        public IFormFile PhotoFile { get; set; }
        public byte[] Photo { get; set; }
        public string? UserDescription { get; set; }
        [StringLength(12, MinimumLength = 10, ErrorMessage = "Номер некоректний")]
        public string PhoneNumber { get; set; }
    }
}
