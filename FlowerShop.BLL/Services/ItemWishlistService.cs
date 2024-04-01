using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Services
{
    public class ItemWishlistService : IItemWishlistService
    {
        public Task<Guid> AddAsync(ItemWishlistModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemWishlistModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemWishlistModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ItemWishlistModel model)
        {
            throw new NotImplementedException();
        }
    }
}
