using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models
{
    public class ItemOrderModel
    {
        private ItemOrderModel(Guid orderId, Guid itemId)
        {
            OrderId = orderId;
            ItemId = itemId;
        }
        public Guid OrderId { get; }
        public Guid ItemId { get; }

        public static (ItemOrderModel, string Error) Create(Guid orderId, Guid itemId)
        {
            var error = string.Empty;

            if(orderId == Guid.Empty)
            {
                error = "ItemOrder Order Id error";
            }

            if(itemId == Guid.Empty)
            {
                error = "ItemOrder Item Id error";
            }

            var itemOrder = new ItemOrderModel(orderId, itemId);

            return (itemOrder, error);
        }

    }
}
