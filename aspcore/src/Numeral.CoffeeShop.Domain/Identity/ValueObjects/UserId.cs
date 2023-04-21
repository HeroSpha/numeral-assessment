using Numeral.CoffeeShop.Domain.Models;

namespace Numeral.CoffeeShop.Domain.Identity.ValueObjects;

public sealed class UserId : AggregateRootId<Guid>
{
    private UserId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override Guid Value { get; protected set; }

    public static UserId Create(Guid value)
    {
        return new(value);
    }
    
    public static UserId Create(string value)
    {
        return Create(Guid.Parse(value));
    }
    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}