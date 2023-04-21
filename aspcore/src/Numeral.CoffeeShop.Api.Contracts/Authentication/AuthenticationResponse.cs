using System.Security.AccessControl;

namespace Numeral.CoffeeShop.Api.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Role,
    string Email,
    string Token);