using Numeral.CoffeeShop.Domain.Models;

namespace Numeral.CoffeeShop.Domain.OrderAggregate.ValueObjects;

public class OrderId : AggregateRootId<Guid>
{
   // public Guid Value { get; set; }

    private OrderId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public static OrderId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public static OrderId Create(string value)
    {
        return !Guid.TryParse(value, out Guid objGuid) ? new(objGuid) : new OrderId(objGuid);
    }
    public static OrderId Create(Guid value)
    {
        return new(value);
    }

    private OrderId()
    {
        
    }

    public override Guid Value { get; protected set; }
}