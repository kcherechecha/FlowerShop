using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Services
{
    public class ItemOrderService : IItemOrderService
    {
        public Task<Guid> AddAsync(ItemOrderModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemOrderModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemOrderModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ItemOrderModel model)
        {
            throw new NotImplementedException();
        }
    }
}
