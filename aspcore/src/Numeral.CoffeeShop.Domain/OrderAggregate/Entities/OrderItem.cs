
using Numeral.CoffeeShop.Domain.MenuItemAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.Models;
using Numeral.CoffeeShop.Domain.OrderAggregate.ValueObjects;

namespace Numeral.CoffeeShop.Domain.OrderAggregate.Entities;

public class OrderItem : Entity<OrderItemId>
{
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    private OrderItem(OrderItemId id, int quantity, decimal price) : base(id)
    {
        Quantity = quantity;
        Price = price;
    }

    public static OrderItem Create(
        int quantity, decimal price)
    {
        return new(OrderItemId.CreateUnique(), quantity, price);
    }

#pragma warning disable CS8618
    private OrderItem(){ }
#pragma warning restore CS8618
}