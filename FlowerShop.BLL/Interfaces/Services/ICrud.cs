using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Interfaces.Services
{
    public interface ICrud<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<Guid> AddAsync(T model); 
        Task DeleteAsync(Guid id);
        Task UpdateAsync(T model);
    }
}
