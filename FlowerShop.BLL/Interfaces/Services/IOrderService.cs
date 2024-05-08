using FlowerShop.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Interfaces.Services
{
    public interface IOrderService : ICrud<OrderModel>
    {
        Task AddItemToOrder(Guid orderId, Guid userId);
    }
}
