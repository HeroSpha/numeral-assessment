using ErrorOr;
using MediatR;
using Numeral.CoffeeShop.Application.Authentication.Common;

namespace Numeral.CoffeeShop.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password, string Role) : IRequest<ErrorOr<AuthenticationResult>>;