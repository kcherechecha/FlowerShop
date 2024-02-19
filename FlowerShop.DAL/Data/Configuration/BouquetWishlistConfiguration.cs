using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class BouquetWishlistConfiguration : IEntityTypeConfiguration<BouquetWishlist>
{
    public void Configure(EntityTypeBuilder<BouquetWishlist> builder)
    {
        builder.ToTable("BouquetWishlists");

        builder.HasKey(bw => new { bw.BouquetId, bw.WishlistId });

        builder.HasOne(bw => bw.Bouquet)
            .WithMany(b => b.BouquetWishlists)
            .HasForeignKey(bw => bw.BouquetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bw => bw.Wishlist)
            .WithMany(w => w.BouquetWishlists)
            .HasForeignKey(bw => bw.WishlistId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
