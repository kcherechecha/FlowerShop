using AutoMapper;
using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
using FlowerShop.BLL.Models.ViewModels;
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

        public async Task<ItemVm> GetById(Guid id)
        {
            var entity = await _context.Items
                .Include(e => e.Category)
                .FirstOrDefaultAsync(e => e.Id == id);

            var model = _mapper.Map<ItemVm>(entity);

            return model;
        }

        public async Task<IEnumerable<ItemListVm>> GetAllAsync()
        {
            var entity = await _context.Items
                .Include(e => e.Category)
                .ToListAsync();

            var model = _mapper.Map<IEnumerable<ItemListVm>>(entity);

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

        public async Task<IEnumerable<ItemListVm>> GetWishlistItem(Guid UserId)
        {
            var entities = await _context.Items
                                .Include(e => e.ItemWishlists)
                                .Where(e => e.ItemWishlists.Any(x => x.UserId == UserId))
                                .ToListAsync();

            var models = _mapper.Map<IEnumerable<ItemListVm>>(entities);

            return models;
        }

        public async Task AddItemToWishlist(Guid itemId, Guid userId)
        {
            var itemWishlistEntity = new ItemWishlist()
            {
                ItemId = itemId,
                UserId = userId
            };

            await _context.ItemWishlists.AddAsync(itemWishlistEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemFromWishlist(Guid itemId, Guid userId)
        {
            var itemWishlistEntity = new ItemWishlist()
            {
                ItemId = itemId,
                UserId = userId
            };

            _context.ItemWishlists.Remove(itemWishlistEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemListVm>> GetItemInBasket(Guid UserId)
        {
            var entities = await _context.Items
                                .Include(e => e.ItemWishlists)
                                .Where(e => e.ItemOrders.Any(x => x.UserId == UserId && x.OrderId == null))
                                .ToListAsync();

            var models = _mapper.Map<IEnumerable<ItemListVm>>(entities);

            return models;
        }

        public async Task<Guid> AddItemToBasket(Guid itemId, Guid userId, int itemCount)
        {
            var itemOrder = new ItemOrder()
            {
                ItemId = itemId,
                UserId = userId,
                ItemCount = itemCount,
            };

            await _context.ItemOrders.AddAsync(itemOrder);
            await _context.SaveChangesAsync();

            return itemOrder.Id;
        }

        public async Task DeleteItemFromBasket(Guid itemId, Guid userId)
        {
            var entity = await _context.ItemOrders
                                .Where(io => io.ItemId == itemId && io.UserId == userId && io.OrderId == null)
                                .FirstOrDefaultAsync();

            _context.ItemOrders.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemCountInBasket(Guid itemId, Guid userId, int count)
        {
            var entity = await _context.ItemOrders
                .Where(io => io.ItemId == itemId && io.UserId == userId && io.OrderId == null)
                .ExecuteUpdateAsync(e => e
                .SetProperty(p => p.ItemCount, count));

            await _context.SaveChangesAsync();
        }

    }
}
