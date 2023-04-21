namespace Numeral.CoffeeShop.Api.Contracts.Orders;

public record OrderItemRequest(
    decimal Price,
    int Quantity
);