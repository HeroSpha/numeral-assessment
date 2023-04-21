using Numeral.CoffeeShop.Domain.Models;

namespace Numeral.CoffeeShop.Domain.CustomerAggregate.ValueObjects;

public sealed class RewardId :  ValueObject
{
    public Guid Value { get;  }

    private RewardId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static RewardId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static RewardId Create(Guid value)
    {
        return new(value);
    }
    
    private RewardId() {}
}