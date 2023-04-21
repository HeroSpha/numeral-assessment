using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.Models;

namespace Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;

public sealed class LoyaltyProgram : AggregateRoot<LoyaltyProgramId, Guid>
{
    public string Name { get; private set; }
    public double PointConversionRate { get; private set; } // 0.1
    public decimal PointRedemptionRate { get; private set; } //1.2
    private LoyaltyProgram(LoyaltyProgramId id, double pointConversionRate, decimal pointRedemptionRate, string name) : base(id)
    {
        PointConversionRate = pointConversionRate;
        PointRedemptionRate = pointRedemptionRate;
        Name = name;
    }

    public LoyaltyProgram UpdateLoyaltyProgram(double pointConversionRate, decimal pointRedemptionRate, string name)
    {
        PointRedemptionRate = pointRedemptionRate;
        PointConversionRate = pointConversionRate;
        Name = name;
        return this;
    }

    public static LoyaltyProgram Create(double pointConversionRate, decimal pointRedemptionRate, string name)
    {
        return new(LoyaltyProgramId.CreateUnique(), pointConversionRate, pointRedemptionRate, name);
    }

#pragma warning disable CS8618
    private LoyaltyProgram() { }
#pragma warning restore CS8618
}