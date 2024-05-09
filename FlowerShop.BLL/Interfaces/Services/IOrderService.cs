using FlowerShop.BLL.Models;
using FlowerShop.BLL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Guid> AddAsync(OrderModel model);
        Task AddItemToOrder(Guid orderId, Guid userId);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<OrderVm>> GetAllAsync();
        Task<OrderVm> GetById(Guid id);
        Task<IEnumerable<OrderVm>> GetByUser(Guid userId);
        Task UpdateAsync(OrderModel model);
    }
}
