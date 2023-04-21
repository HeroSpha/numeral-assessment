namespace Numeral.CoffeeShop.Api.Contracts.LoyaltyProgram;

public record LoyaltyProgramResponse(
    string Id,
    string Name,
    int PointConversionRate,
    int MinimumPointsToRedeem,
    decimal PointRedemptionRate);