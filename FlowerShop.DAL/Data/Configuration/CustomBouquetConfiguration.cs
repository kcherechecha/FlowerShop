using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FlowerShop.DAL.Entities;

namespace FlowerShop.DAL.Data.Configuration
{
    public class CustomBouquetConfiguration : IEntityTypeConfiguration<CustomBouquet>
    {
        public void Configure(EntityTypeBuilder<CustomBouquet> builder)
        {
            builder.ToTable("CustomBouquets");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Photo)
                .HasColumnType("bytea");

            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(12);

            builder.Property(c => c.UserId)
                .IsRequired();

            builder.Property(c => c.UserDescription)
                .HasMaxLength(1000);

            builder.Property(c => c.RequestTime)
                .IsRequired();
        }
    }
}
