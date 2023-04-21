namespace Numeral.CoffeeShop.Api.Contracts.MenuItems;

public record MenuItemResponse(
    string Id,
    string Name,
    string Description,
    string Image,
    decimal Price,
    bool IsAvailable,
    string LoyaltyProgramId);