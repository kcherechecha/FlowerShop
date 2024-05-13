using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models
{
    public class ItemOrdersCountUpdate
    {
        public Guid itemId { get; set; }
        public int quantity { get; set; }
    }
}
