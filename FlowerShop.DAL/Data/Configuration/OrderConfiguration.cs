using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(o => o.OrderId);

        builder.Property(o => o.OrderAddress)
            .HasMaxLength(255); 

        builder.Property(o => o.OrderTime)
            .IsRequired();

        builder.Property(o => o.UserId)
            .IsRequired();

        builder.Property(o => o.BasketId)
            .IsRequired();

        builder.Property(o => o.OrderStatusId)
            .IsRequired();
        
        builder.HasOne(o => o.Basket)
            .WithOne(b => b.Order)
            .HasForeignKey<Basket>(b => b.Id)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}