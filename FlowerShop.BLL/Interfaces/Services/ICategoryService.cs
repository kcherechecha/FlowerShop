using FlowerShop.BLL.Models;
using FlowerShop.BLL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<Guid> AddAsync(CategoryModel model);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<CategoryVm>> GetAllAsync();
        Task<CategoryVm> GetById(Guid id);
        Task UpdateAsync(CategoryModel model);
    }
}
