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
        public Guid Id { get; }
        public IFormFile? Photo { get; }
        public Guid UserId { get; }
        public string? UserDescription { get; }
        public DateTime RequestTime { get; private set; } = DateTime.Now;
    }
}
