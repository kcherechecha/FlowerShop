using FlowerShop.WebAPI.Models;

namespace FlowerShop.WebAPI.Interfaces
{
    public interface IIdentityService
    {
        Task<int> AddPhoneNumber(string phone, string id);
        Task<Role> GetRole(string id);
        Task<User> GetUser(string id);
    }
}
