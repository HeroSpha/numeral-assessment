using Numeral.CoffeeShop.Domain.Models;

namespace Numeral.CoffeeShop.Domain.CustomerAggregate.ValueObjects;

public sealed class CustomerId : AggregateRootId<Guid>
{
    //public Guid Value { get;  }

    private CustomerId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static CustomerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static CustomerId Create(Guid value)
    {
        return new (value);
    }
    public static CustomerId Create(string value)
    {
        return new(Guid.Parse(value));
    }
    

    public override Guid Value { get; protected set; }
}