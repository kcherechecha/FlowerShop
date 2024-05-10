
using FlowerShop.WebAPI.Data;
using FlowerShop.WebAPI.Interfaces;
using FlowerShop.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FlowerShop.WebAPI.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly FlowerIdentityDbContext _context;

        public IdentityService(FlowerIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(string id)
        {
            var entity = await _context.Users.FindAsync(id);

            var user = new User()
            {
                Id = new Guid(entity.Id),
                Email = entity.Email,
                Name = entity.UserName,
            };

            return user;
        }
    }
}
