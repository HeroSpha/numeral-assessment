namespace Numeral.CoffeeShop.Api.Contracts.Orders;

public record OrderResponse(
    string CustomerId,
    decimal OrderTotal,
    DateTime OrderDate,
    string Status,
    IEnumerable<OrderItemResponse> OrderItems);

public record OrderItemResponse(
    decimal Price,
    int Quantity);