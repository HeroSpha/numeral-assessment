namespace Numeral.CoffeeShop.Api.Contracts.Orders;

public record OrderItemRequest(
    string MenuItemId,
    int Quantity
);