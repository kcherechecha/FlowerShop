using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Services
{
    public class CustomBouquetService : ICustomBouquetService
    {
        public Task<Guid> AddAsync(CustomBouquetModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomBouquetModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomBouquetModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CustomBouquetModel model)
        {
            throw new NotImplementedException();
        }
    }
}
