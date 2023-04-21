using MediatR;

using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;

namespace Numeral.CoffeeShop.Application.LoyaltyPrograms.Queries.list;

public record GetLoyaltyProgramsQuery : IRequest<IEnumerable<LoyaltyProgram>>;