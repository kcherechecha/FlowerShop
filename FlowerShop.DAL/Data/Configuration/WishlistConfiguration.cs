using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DAL.Data.Configuration
{
    public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.ToTable("Wishlists");

            builder.HasKey(w => w.UserId);

            builder.Property(w => w.UserId)
                .IsRequired();

            builder.HasMany(w => w.ItemWishlists)
                .WithOne(bw => bw.Wishlist)
                .HasForeignKey(bw => bw.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
