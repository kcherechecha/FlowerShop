using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Services;
using FlowerShop.DAL.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutomapperProfile).Assembly);

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomBouquetService, CustomBouquetService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
