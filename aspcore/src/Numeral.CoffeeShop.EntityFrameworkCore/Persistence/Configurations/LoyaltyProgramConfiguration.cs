using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate.ValueObjects;

namespace Numeral.CoffeeShop.EntityFrameworkCore.Persistence.Configurations;

public class LoyaltyProgramConfiguration : IEntityTypeConfiguration<LoyaltyProgram>
{
    public void Configure(EntityTypeBuilder<LoyaltyProgram> builder)
    {
        ConfigureLoyaltyProgramsTable(builder);
    }

    private void ConfigureLoyaltyProgramsTable(EntityTypeBuilder<LoyaltyProgram> builder)
    {
        builder.ToTable("LoyaltyPrograms");

        builder.HasKey(x => x.Id);

        builder.Property(l => l.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => LoyaltyProgramId.Create(value));

        builder.Property(l => l.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}