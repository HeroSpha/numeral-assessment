using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Numeral.CoffeeShop.Domain.CustomerAggregate;
using Numeral.CoffeeShop.Domain.CustomerAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate.ValueObjects;

namespace Numeral.CoffeeShop.EntityFrameworkCore.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        ConfigureCustomersTable(builder);
        ConfigureCustomerRewardsTable(builder);
    }

    private void ConfigureCustomerRewardsTable(EntityTypeBuilder<Customer> builder)
    {
        builder.OwnsMany(c => c.Rewards, rb =>
        {
            rb.ToTable(nameof(Customer.Rewards));

            rb.WithOwner().HasForeignKey("CustomerId");

            rb.HasKey("Id", "CustomerId");
            
            rb.Property(r => r.Id)
                .HasColumnName("RewardId")
                .ValueGeneratedNever()
                .HasConversion(
                    r => r.Value,
                    value => RewardId.Create(value));
            
            builder.Metadata.FindNavigation(nameof(Customer.Rewards))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        });
    }

    private void ConfigureCustomersTable(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => CustomerId.Create(value));
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .IsRequired();

    }
}