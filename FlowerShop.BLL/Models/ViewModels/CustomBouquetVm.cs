using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models.ViewModels
{
    public class CustomBouquetVm
    {
        public Guid Id { get; set; }
        public byte[]? Photo { get; set; }
        public Guid UserId { get; set; }
        public string? UserDescription { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
