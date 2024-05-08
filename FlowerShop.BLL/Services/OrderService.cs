using AutoMapper;
using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
using FlowerShop.BLL.Models.ViewModels;
using FlowerShop.DAL.Data;
using FlowerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace FlowerShop.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly FlowerDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(FlowerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddAsync(OrderModel model)
        {
            var entity = _mapper.Map<Order>(model);

            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = new Order() { Id = id};

            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            var entities = await _context.Orders
                .Include(e => e.OrderStatus)
                .ToListAsync();

            var models = _mapper.Map<IEnumerable<OrderModel>>(entities);

            return models;
        }

        public async Task<IEnumerable<OrderModel>> GetByUser(Guid userId)
        {
            var entities = await _context.Orders
                .Where(e => e.UserId == userId)
                .Include(e => e.OrderStatus)
                .ToListAsync();

            var models = _mapper.Map<IEnumerable<OrderModel>>(entities);

            return models;
        }

        public async Task<OrderModel> GetById(Guid id)
        {
            var entities = await _context.Orders
                .Include(e => e.OrderStatus)
                .FirstOrDefaultAsync(e => e.Id == id);

            var models = _mapper.Map<OrderModel>(entities);

            return models;
        }

        public async Task UpdateAsync(OrderModel model)
        {
            var entity = await _context.Orders
                .ExecuteUpdateAsync(e => e
                .SetProperty(p => p.OrderAddress, model.OrderAddress));

            await _context.SaveChangesAsync();
        }

        public async Task AddItemToOrder(Guid orderId, Guid userId)
        {
            var entity = await _context.ItemOrders
                .Where(io => io.UserId == userId && io.OrderId == null)
                .ExecuteUpdateAsync(io => io
                .SetProperty(p => p.OrderId, orderId));

            await _context.SaveChangesAsync();
        }
    }
}
