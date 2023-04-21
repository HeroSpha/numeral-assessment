using MediatR;
using ErrorOr;
using Numeral.CoffeeShop.Application.Authentication.Common;

namespace Numeral.CoffeeShop.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) 
    : IRequest<ErrorOr<AuthenticationResult>>;