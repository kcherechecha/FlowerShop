using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
{
    public void Configure(EntityTypeBuilder<Wishlist> builder)
    {
        builder.ToTable("Wishlists");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.UserId)
            .IsRequired();

        builder.HasMany(w => w.BouquetWishlists)
            .WithOne(bw => bw.Wishlist)
            .HasForeignKey(bw => bw.WishlistId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
