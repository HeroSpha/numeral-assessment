namespace Numeral.CoffeeShop.Api.Contracts.MenuItems;

public record CreateMenuItemRequest(
    string Name,
    string Description,
    string Image,
    decimal Price,
    bool IsAvailable,
    string LoyaltyProgramId);