using AutoMapper;
using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
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

        public async Task<IEnumerable<CustomBouquetModel>> GetAllAsync()
        {
            var entities = await _context.CustomBouquets.ToListAsync();

            var models = _mapper.Map<IEnumerable<CustomBouquetModel>>(entities);

            return models;
        }

        public async Task<CustomBouquetModel> GetById(Guid id)
        {
            var entity = await _context.CustomBouquets.FindAsync(id);

            var models = _mapper.Map<CustomBouquetModel>(entity);

            return models;
        }

        public async Task UpdateAsync(CustomBouquetModel model)
        {
            var entity = _mapper.Map<CustomBouquet>(model);

            await _context.SaveChangesAsync();
        }
    }
}
