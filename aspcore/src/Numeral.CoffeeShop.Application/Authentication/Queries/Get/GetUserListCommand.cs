using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Domain.Identity;

namespace Numeral.CoffeeShop.Application.Authentication.Queries.Get;

public record GetUserListCommand() : IRequest<IEnumerable<User>>;
