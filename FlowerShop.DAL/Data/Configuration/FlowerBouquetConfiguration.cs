using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class FlowerBouquetConfiguration : IEntityTypeConfiguration<FlowerBouquet>
{
    public void Configure(EntityTypeBuilder<FlowerBouquet> builder)
    {
        builder.ToTable("FlowerBouquets");

        builder.HasKey(fb => new { fb.FlowerId, fb.BouquetId });

        builder.HasOne(fb => fb.Flower)
            .WithMany(f => f.FlowerBouquets)
            .HasForeignKey(fb => fb.FlowerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(fb => fb.Bouquet)
            .WithMany(b => b.FlowerBouquets)
            .HasForeignKey(fb => fb.BouquetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
