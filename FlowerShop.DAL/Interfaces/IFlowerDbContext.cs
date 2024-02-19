using Microsoft.EntityFrameworkCore;

public interface IFlowerDbContext
{
    DbSet<Basket> Baskets {get;}
    DbSet<Bouquet> Bouquets {get;}
    DbSet<BouquetBasket> BouquetBaskets {get;}
    DbSet<BouquetWishlist> BouquetWishlists {get;}
    DbSet<Flower> Flowers {get;}
    DbSet<FlowerBouquet> FlowerBouquets {get;}
    DbSet<Order> Orders {get;}
    DbSet<OrderStatus> OrderStatuses {get;}
    DbSet<Wishlist> Wishlists {get;}
}