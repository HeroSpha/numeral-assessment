using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;

namespace Numeral.CoffeeShop.Application.LoyaltyPrograms.Commands.Create;

public record CreateLoyaltyProgramCommand(
    string Name,
    int PointConversionRate,
    decimal PointRedemptionRate): IRequest<ErrorOr<LoyaltyProgram>>;