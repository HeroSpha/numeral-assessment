namespace Numeral.CoffeeShop.Api.Contracts.Orders;

public record CreateOrderRequest(
    IEnumerable<OrderItemRequest> OrderItems);