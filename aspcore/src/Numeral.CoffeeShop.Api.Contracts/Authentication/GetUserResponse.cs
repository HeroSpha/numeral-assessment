namespace Numeral.CoffeeShop.Api.Contracts.Authentication;

public record GetUserResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Role,
    string Email);