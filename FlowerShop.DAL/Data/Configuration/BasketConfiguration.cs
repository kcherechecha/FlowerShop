using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.ToTable("Baskets");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.UserId)
            .IsRequired();

        builder.HasOne(b => b.Order)
            .WithOne(o => o.Basket)
            .HasForeignKey<Order>(o => o.BasketId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}