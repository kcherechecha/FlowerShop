using FlowerShop.WebAPI.Models;

namespace FlowerShop.WebAPI.Interfaces
{
    public interface IIdentityService
    {
        Task<User> GetUser(string id);
    }
}
