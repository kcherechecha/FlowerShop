using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models.ViewModels
{
    public class OrderVm
    {
        public Guid Id { get; set; }
        public string? OrderAddress { get; set; }
        public string PhoneNumber { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime OrderTime { get; set; }
        public Guid UserId { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
    }
}
