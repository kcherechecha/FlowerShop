using FlowerShop.BLL.Models;
using FlowerShop.BLL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Interfaces.Services
{
    public interface IItemService
    {
        Task<Guid> AddAsync(ItemModel model);
        Task<Guid> AddItemToBasket(Guid itemId, Guid userId, int itemCount);
        Task AddItemToWishlist(Guid itemId, Guid userId);
        Task CreateWishlist(Guid userId);
        Task DeleteAsync(Guid id);
        Task DeleteItemFromBasket(Guid itemId, Guid userId);
        Task DeleteItemFromWishlist(Guid itemId, Guid userId);
        Task<IEnumerable<ItemListVm>> GetAllAsync();
        Task<IEnumerable<ItemListVm>> GetLatestAsync(int count);
        Task<IEnumerable<ItemListVm>> GetByCategoryAsync(string category);
        Task<ItemVm> GetById(Guid id);
        Task<IEnumerable<ItemListVm>> GetItemInBasket(Guid UserId);
        Task<IEnumerable<ItemListVm>> GetWishlistItem(Guid UserId);
        Task UpdateAsync(ItemModel model);
        Task UpdateItemCountInBasket(Guid itemId, Guid userId, int count);
    }
}
