using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models
{
    public class ItemOrderModel
    {
        private ItemOrderModel(Guid orderId, Guid itemId, Guid id, int itemCount)
        {
            OrderId = orderId;
            ItemId = itemId;
            Id = id;
            ItemCount = itemCount;
        }
        public Guid Id { get; }
        public Guid OrderId { get; }
        public Guid ItemId { get; }
        public int ItemCount { get; }

        public static (ItemOrderModel, string Error) Create(Guid id, Guid orderId, Guid itemId, int itemCount)
        {
            var error = string.Empty;

            if (id == Guid.Empty)
            {
                error = "ItemOrder Order Id error";
            }

            if (orderId == Guid.Empty)
            {
                error = "ItemOrder Order Id error";
            }

            if(itemId == Guid.Empty)
            {
                error = "ItemOrder Item Id error";
            }

            if(itemCount < 1)
            {
                error = "ItemOrder count less than one";
            }

            var itemOrder = new ItemOrderModel(id, orderId, itemId, itemCount);

            return (itemOrder, error);
        }

    }
}
