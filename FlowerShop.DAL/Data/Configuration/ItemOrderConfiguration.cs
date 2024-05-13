using FlowerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DAL.Data.Configuration
{
    public class ItemOrderConfiguration : IEntityTypeConfiguration<ItemOrder>
    {
        public void Configure(EntityTypeBuilder<ItemOrder> builder)
        {
            builder.ToTable("ItemOrders");

            builder.HasKey(io => io.Id);

            builder.Property(io => io.ItemCount)
                .IsRequired();

            builder.Property(io => io.UserId) 
                .IsRequired();

            builder.HasOne(io => io.Order)
                .WithMany(o => o.ItemOrders)
                .HasForeignKey(io => io.OrderId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false); 

            builder.HasOne(io => io.Item)
                .WithMany(i => i.ItemOrders)
                .HasForeignKey(io => io.ItemId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
