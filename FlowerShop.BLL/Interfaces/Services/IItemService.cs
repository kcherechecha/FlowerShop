using FlowerShop.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Interfaces.Services
{
    public interface IItemService : ICrud<ItemModel>
    {
        Task<Guid> AddItemToBasket(Guid itemId, Guid userId, int itemCount);
        Task AddItemToWishlist(Guid itemId, Guid userId);
        Task DeleteItemFromBasket(Guid itemId, Guid userId);
        Task DeleteItemFromWishlist(Guid itemId, Guid userId);
        Task<IEnumerable<ItemModel>> GetItemInBasket(Guid UserId);
        Task<IEnumerable<ItemModel>> GetWishlistItem(Guid UserId);
        Task UpdateItemCountInBasket(Guid itemId, Guid userId, int count);
    }
}
