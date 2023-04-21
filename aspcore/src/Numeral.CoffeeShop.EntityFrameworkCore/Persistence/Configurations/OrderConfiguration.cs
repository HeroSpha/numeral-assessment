using System.Security.Principal;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Numeral.CoffeeShop.Domain.CustomerAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.MenuItemAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.OrderAggregate;
using Numeral.CoffeeShop.Domain.OrderAggregate.ValueObjects;

namespace Numeral.CoffeeShop.EntityFrameworkCore.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        ConfigureOrdersTable(builder);
        ConfigureOrdersItemsTable(builder);
    }

    private void ConfigureOrdersItemsTable(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsMany(c => c.OrderItems, oib =>
        {
            oib.ToTable(nameof(Order.OrderItems));

            oib.WithOwner().HasForeignKey("OrderId");

            oib.HasKey("Id", "OrderId");
            
            oib.Property(r => r.Id)
                .HasColumnName("OrderItemId")
                .ValueGeneratedNever()
                .HasConversion(
                    r => r.Value,
                    value => OrderItemId.Create(value));

            oib.Property(oi => oi.Price)
                .HasPrecision(19, 4)
                .IsRequired();

            builder.Metadata.FindNavigation(nameof(Order.OrderItems))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        });
    }

    private void ConfigureOrdersTable(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => OrderId.Create(value));
        
        builder.Property(o => o.CustomerId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => CustomerId.Create(value));
        builder.Property(o => o.OrderTotal)
            .HasPrecision(19, 4);
        
    }
}