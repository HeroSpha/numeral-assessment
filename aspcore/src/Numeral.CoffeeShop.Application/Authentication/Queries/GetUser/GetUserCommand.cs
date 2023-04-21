using ErrorOr;
using MediatR;
using Numeral.CoffeeShop.Domain.Identity;

namespace Numeral.CoffeeShop.Application.Authentication.Queries.GetUser;

public record GetUserCommand(string Id): IRequest<ErrorOr<User>>;