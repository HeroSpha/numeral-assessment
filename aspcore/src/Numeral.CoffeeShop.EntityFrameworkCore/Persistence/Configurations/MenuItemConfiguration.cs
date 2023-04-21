using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.MenuItemAggregate;
using Numeral.CoffeeShop.Domain.MenuItemAggregate.ValueObjects;

namespace Numeral.CoffeeShop.EntityFrameworkCore.Persistence.Configurations;

public class MenuItemConfiguration  : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        ConfigureMenuItemsTable(builder);
    }

    private void ConfigureMenuItemsTable(EntityTypeBuilder<MenuItem> builder)
    {
        builder.ToTable("MenuItems");
        builder.HasKey(m => m.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuItemId.Create(value));
        
        
        builder.Property(p => p.LoyaltyProgramId)
            .ValueGeneratedNever()
            .HasConversion(
                loyaltyProgramId => loyaltyProgramId.Value,
                value => LoyaltyProgramId.Create(value))
            .IsRequired();
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.Price)
            .HasPrecision(19, 4);
    }
}