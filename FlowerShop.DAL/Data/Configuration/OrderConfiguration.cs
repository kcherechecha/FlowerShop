using FlowerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DAL.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .IsRequired();

            builder.Property(o => o.OrderAddress)
                .HasMaxLength(255);

            builder.Property(o => o.OrderPrice)
                .IsRequired();

            builder.Property(o => o.OrderTime)
                .IsRequired();

            builder.Property(o => o.UserId)
                .IsRequired();

            builder.Property(o => o.OrderStatusId)
                .IsRequired();

            builder.HasOne(o => o.OrderStatus)
                .WithMany(os => os.Orders)
                .HasForeignKey(o => o.OrderStatusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(o => o.ItemOrders)
                .WithOne(io => io.Order)
                .HasForeignKey(io => io.OrderId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}