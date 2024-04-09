using AutoMapper;
using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
using FlowerShop.DAL.Data;
using FlowerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace FlowerShop.BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly FlowerDbContext _context;
        private readonly IMapper _mapper;

        public ItemService(FlowerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddAsync(ItemModel model)
        {
            var entity = _mapper.Map<Item>(model);

            await _context.Items.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = new Item() { Id = id };

            _context.Items.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ItemModel> GetById(Guid id)
        {
            var entity = await _context.Items
                .Include(e => e.Category)
                .FirstOrDefaultAsync(e => e.Id == id);

            var model = _mapper.Map<ItemModel>(entity);

            return model;
        }

        public async Task<IEnumerable<ItemModel>> GetAllAsync()
        {
            var entity = await _context.Items
                .Include(e => e.Category)
                .ToListAsync();

            var model = _mapper.Map<IEnumerable<ItemModel>>(entity);

            return model;
        }

        public async Task UpdateAsync(ItemModel model)
        {
            var entity = await _context.Items
                .ExecuteUpdateAsync(e => e
                .SetProperty(p => p.Name, model.Name)
                .SetProperty(p => p.CategoryId, model.CategoryId)
                .SetProperty(p => p.Description, model.Description));

            await _context.SaveChangesAsync(); 
        }
    }
}
