namespace Numeral.CoffeeShop.Api.Contracts.LoyaltyProgram;

public record CreateLoyaltyProgramRequest(
    string Name,
    int PointConversionRate,
    int MinimumPointsToRedeem,
    decimal PointRedemptionRate);