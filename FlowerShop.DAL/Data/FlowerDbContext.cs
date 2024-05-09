using FlowerShop.DAL.Entities;
using FlowerShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FlowerShop.DAL.Data
{
    public class FlowerDbContext : DbContext, IFlowerDbContext
    {
        public FlowerDbContext(DbContextOptions<FlowerDbContext> options) : base(options) 
        {
            SeedData.Initialize(this);
        }

        

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();

        public DbSet<Wishlist> Wishlists => Set<Wishlist>();

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<CustomBouquet> CustomBouquets => Set<CustomBouquet>();

        public DbSet<Item> Items => Set<Item>();

        public DbSet<ItemOrder> ItemOrders => Set<ItemOrder>();

        public DbSet<ItemWishlist> ItemWishlists => Set<ItemWishlist>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}