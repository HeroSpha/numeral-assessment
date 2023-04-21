using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;

namespace Numeral.CoffeeShop.Application.LoyaltyPrograms.Queries.Get;

public record GetLoyaltyProgramQuery(
    string LoyaltyProgramId): IRequest<ErrorOr<LoyaltyProgram>>;