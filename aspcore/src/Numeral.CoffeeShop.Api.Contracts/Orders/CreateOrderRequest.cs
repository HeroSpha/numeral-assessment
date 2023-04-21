namespace Numeral.CoffeeShop.Api.Contracts.Orders;

public record CreateOrderRequest(
    DateTime OrderDate, 
    int LoyaltyPointsEarned,
    IEnumerable<OrderItemRequest> OrderItems,
    string CustomerId);