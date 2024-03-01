using FlowerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace FlowerShop.DAL.Data.Configuration
{
    public class ItemWishlistConfiguration : IEntityTypeConfiguration<ItemWishlist>
    {
        public void Configure(EntityTypeBuilder<ItemWishlist> builder)
        {
            builder.ToTable("ItemWishlists");

            builder.HasKey(iw => new { iw.UserId, iw.ItemId });

            builder.HasOne(iw => iw.Wishlist)
                .WithMany(w => w.ItemWishlists)
                .HasForeignKey(iw => iw.UserId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(iw => iw.Item)
                .WithMany(i => i.ItemWishlists)
                .HasForeignKey(iw => iw.ItemId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
