using AutoMapper;
using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
using FlowerShop.BLL.Models.ViewModels;
using FlowerShop.DAL.Data;
using FlowerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Services
{
    public class CustomBouquetService : ICustomBouquetService
    {
        private readonly FlowerDbContext _context;
        private readonly IMapper _mapper;

        public CustomBouquetService(FlowerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(CustomBouquetModel model)
        {
            var entity = _mapper.Map<CustomBouquet>(model);

            await _context.CustomBouquets.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = new CustomBouquet() { Id = id };

            _context.CustomBouquets.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomBouquetVm>> GetAllAsync()
        {
            var entities = await _context.CustomBouquets.ToListAsync();

            var models = _mapper.Map<IEnumerable<CustomBouquetVm>>(entities);

            return models;
        }

        public async Task<CustomBouquetVm> GetById(Guid id)
        {
            var entity = await _context.CustomBouquets.FindAsync(id);

            var models = _mapper.Map<CustomBouquetVm>(entity);

            return models;
        }

        public async Task UpdateAsync(CustomBouquetModel model)
        {
            var entity = await _context.CustomBouquets
                .Where(e => e.Id == model.Id)
                .ExecuteUpdateAsync(e => e
                .SetProperty(p => p.UserDescription, model.UserDescription));

            await _context.SaveChangesAsync();
        }
    }
}
