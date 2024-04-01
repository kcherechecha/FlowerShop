using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
using FlowerShop.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly FlowerDbContext _context;

        public CategoryService(FlowerDbContext context)
        {
            _context = context;
        }

        public Task<Guid> AddAsync(CategoryModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CategoryModel model)
        {
            throw new NotImplementedException();
        }
    }
}
