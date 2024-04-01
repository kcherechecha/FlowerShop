using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Services
{
    public class WishlistService : IWishlistService
    {
        public Task<Guid> AddAsync(WishlistModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WishlistModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WishlistModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WishlistModel model)
        {
            throw new NotImplementedException();
        }
    }
}
