using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Services
{
    public class OrderService : IOrderService
    {
        public Task<Guid> AddAsync(OrderModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrderModel model)
        {
            throw new NotImplementedException();
        }
    }
}
