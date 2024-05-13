using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models.InputModels
{
    public class CustomBouquetInputModel
    {
        public Guid Id { get; set; }
        public byte[]? Photo { get; set; }
        public string? UserDescription { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RequestTime { get; private set; } = DateTime.UtcNow;
    }
}
