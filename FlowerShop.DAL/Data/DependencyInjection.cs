using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlowerShop.DAL.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            string migrationsAssemblyName = typeof(FlowerDbContext).Assembly.GetName().Name;

            services.AddDbContext<FlowerDbContext>(options =>
                options.UseNpgsql(connectionString, npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsAssembly(migrationsAssemblyName);
                })
            );

            return services;
        }
    }
}
