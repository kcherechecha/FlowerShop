using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models
{
    public class WishlistModel
    {
        private WishlistModel(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }

        public static (WishlistModel, string Error) Create(Guid userId)
        {
            var error = string.Empty;

            if(userId == Guid.Empty)
            {
                error = "Wishlist User Id error";
            }

            var wishlist = new WishlistModel(userId);

            return (wishlist, error);
        }
    }
}
