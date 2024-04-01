using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Services
{
    public class ItemService : IItemService
    {
        public Task<Guid> AddAsync(ItemModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ItemModel model)
        {
            throw new NotImplementedException();
        }
    }
}
