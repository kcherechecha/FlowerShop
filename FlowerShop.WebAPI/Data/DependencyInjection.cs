using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.WebAPI.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FlowerIdentityDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("IdentityConnection"), npgsqlOptions =>
                {
                })
            );

            services.AddAuthorization();

            services.AddIdentityApiEndpoints<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<FlowerIdentityDbContext>();

            return services;
        }
    }
}
