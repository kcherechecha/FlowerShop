using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models.ViewModels
{
    public class ItemVm
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Photo { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
