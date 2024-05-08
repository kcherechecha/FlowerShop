using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models.InputModels
{
    public class OrderInputModel
    {
        public Guid Id { get; set; }
        public string? OrderAddress { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime OrderTime { get; private set; } = DateTime.UtcNow;
        public int OrderStatusId { get; private set; } = 1;
    }
}
