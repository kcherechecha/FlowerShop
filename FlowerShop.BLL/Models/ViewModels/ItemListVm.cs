using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models.ViewModels
{
    public class ItemListVm
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
