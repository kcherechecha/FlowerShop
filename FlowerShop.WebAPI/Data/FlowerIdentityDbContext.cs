using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.WebAPI.Data
{
    public class FlowerIdentityDbContext : IdentityDbContext
    {
        public FlowerIdentityDbContext(DbContextOptions<FlowerIdentityDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
