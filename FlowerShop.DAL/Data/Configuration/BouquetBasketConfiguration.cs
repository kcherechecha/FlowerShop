using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class BouquetBasketConfiguration : IEntityTypeConfiguration<BouquetBasket>
{
    public void Configure(EntityTypeBuilder<BouquetBasket> builder)
    {
        builder.ToTable("BouquetBaskets");

        builder.HasKey(bb => new { bb.BasketId, bb.BouquetId });

        builder.HasOne(bb => bb.Basket)
            .WithMany(b => b.BouquetBaskets)
            .HasForeignKey(bb => bb.BasketId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bb => bb.Bouquet)
            .WithMany(b => b.BouquetBaskets)
            .HasForeignKey(bb => bb.BouquetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
