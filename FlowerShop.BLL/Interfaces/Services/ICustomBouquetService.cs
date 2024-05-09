using FlowerShop.BLL.Models;
using FlowerShop.BLL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Interfaces.Services
{
    public interface ICustomBouquetService
    {
        Task<Guid> AddAsync(CustomBouquetModel model);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<CustomBouquetVm>> GetAllAsync();
        Task<CustomBouquetVm> GetById(Guid id);
        Task UpdateAsync(CustomBouquetModel model);
    }
}
