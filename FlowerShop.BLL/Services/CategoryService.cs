using AutoMapper;
using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
using FlowerShop.DAL.Data;
using FlowerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly FlowerDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(FlowerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(CategoryModel model)
        {
            var entity = _mapper.Map<Category>(model);

            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = new Category { Id = id };

            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            var entities = await _context.Categories.ToListAsync();

            var models = _mapper.Map<IEnumerable<CategoryModel>>(entities);

            return models;
        }

        public async Task<CategoryModel> GetById(Guid id)
        {
            var entity = await _context.Categories.FindAsync(id);

            var model = _mapper.Map<CategoryModel>(entity);

            return model;
        }

        public async Task UpdateAsync(CategoryModel model)
        {
            var entity = await _context.Categories
                .Where(e => e.Id == model.Id)
                .ExecuteUpdateAsync(e => e
                .SetProperty(p => p.Name, model.Name));

            await _context.SaveChangesAsync();
        }
    }
}
