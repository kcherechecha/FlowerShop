using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.DAL.Entities
{
    public class ItemOrder
    {
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public Item? Item { get; set; }
        public Order? Order { get; set; }
    }
}
