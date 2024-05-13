using FlowerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DAL.Interfaces
{
    public interface IFlowerDbContext
    {
        DbSet<Category> Categories { get; }
        DbSet<CustomBouquet> CustomBouquets { get; }
        DbSet<Item> Items { get; }
        DbSet<ItemOrder> ItemOrders { get; }
        DbSet<ItemWishlist> ItemWishlists { get; }
        DbSet<Order> Orders { get; }
        DbSet<OrderStatus> OrderStatuses { get; }
        DbSet<Wishlist> Wishlists { get; }
    }
}