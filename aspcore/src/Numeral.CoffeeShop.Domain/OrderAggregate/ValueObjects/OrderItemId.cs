
using Numeral.CoffeeShop.Domain.MenuItemAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.Models;

namespace Numeral.CoffeeShop.Domain.OrderAggregate.ValueObjects;

public class OrderItemId : ValueObject
{
    public Guid Value { get; }

    private OrderItemId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static OrderItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static OrderItemId Create(Guid value)
    {
        return new(value);
    }

    private OrderItemId() {}
}