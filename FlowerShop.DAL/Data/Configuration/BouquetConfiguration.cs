using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BouquetConfiguration : IEntityTypeConfiguration<Bouquet>
{
    public void Configure(EntityTypeBuilder<Bouquet> builder)
    {
        builder.ToTable("Bouquets");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
            .HasMaxLength(255);

        builder.Property(b => b.Photo)
            .HasColumnType("bytea");

        builder.Property(b => b.Price)
            .IsRequired();

        builder.HasMany(b => b.FlowerBouquets)
            .WithOne(fb => fb.Bouquet)
            .HasForeignKey(fb => fb.BouquetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(b => b.BouquetWishlists)
            .WithOne(bw => bw.Bouquet)
            .HasForeignKey(bw => bw.BouquetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
