using Microsoft.EntityFrameworkCore;
using System.Reflection;


public class FlowerDbContext : DbContext, IFlowerDbContext
{
    public FlowerDbContext(DbContextOptions<FlowerDbContext> options) : base(options) { }
    public DbSet<Basket> Baskets => Set<Basket>();

    public DbSet<Bouquet> Bouquets => Set<Bouquet>();

    public DbSet<BouquetBasket> BouquetBaskets => Set<BouquetBasket>();

    public DbSet<BouquetWishlist> BouquetWishlists => Set<BouquetWishlist>();

    public DbSet<Flower> Flowers => Set<Flower>();

    public DbSet<FlowerBouquet> FlowerBouquets => Set<FlowerBouquet>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();

    public DbSet<Wishlist> Wishlists => Set<Wishlist>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}