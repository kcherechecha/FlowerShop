using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models
{
    public class ItemWishlistModel
    {
        private ItemWishlistModel(Guid userId, Guid itemId)
        {
            UserId = userId;
            ItemId = itemId;
        }

        public Guid UserId { get; }
        public Guid ItemId { get; }

        public static (ItemWishlistModel, string Error) Create(Guid userId, Guid itemId)
        {
            var error = string.Empty;

            if(userId ==  Guid.Empty)
            {
                error = "ItemWishlist User Id error";
            }

            if(itemId == Guid.Empty)
            {
                error = "ItemWishlist Item Id error";
            }

            var itemWishlist = new ItemWishlistModel(userId, itemId);

            return (itemWishlist, error);
        }
    }
}
