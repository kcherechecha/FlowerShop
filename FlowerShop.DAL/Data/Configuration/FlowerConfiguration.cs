using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

public class FlowerConfiguration : IEntityTypeConfiguration<Flower>
{
    public void Configure(EntityTypeBuilder<Flower> builder)
    {
        builder.ToTable("Flowers");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Name)
            .HasMaxLength(255);

        builder.Property(f => f.Photo)
            .HasColumnType("bytea");

        builder.Property(f => f.Description)
            .HasMaxLength(1000); 

        builder.Property(f => f.Color)
            .HasConversion(
                color => ColorTranslator.ToHtml(color),
                htmlColor => ColorTranslator.FromHtml(htmlColor)
            );

        builder.Property(f => f.Price)
            .IsRequired();

    }
}
