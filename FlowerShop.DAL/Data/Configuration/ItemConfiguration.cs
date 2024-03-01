using FlowerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DAL.Data.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .IsRequired();

            builder.Property(i => i.Name)
                .HasMaxLength(255);

            builder.Property(i => i.Photo)
                .IsRequired();

            builder.Property(i => i.Description)
                .IsRequired(false);

            builder.Property(i => i.Price)
                .IsRequired();

            builder.Property(i => i.CategoryId)
                .IsRequired();

            builder.HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(i => i.ItemWishlists)
                .WithOne(iw => iw.Item)
                .HasForeignKey(iw => iw.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(i => i.ItemOrders)
                .WithOne(io => io.Item)
                .HasForeignKey(io => io.ItemId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}