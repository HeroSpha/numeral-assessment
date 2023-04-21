using System.Globalization;

using Numeral.CoffeeShop.Domain.Models;

namespace Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate.ValueObjects;

public sealed class LoyaltyProgramId : AggregateRootId<Guid>
{
    //public Guid Value { get; }
    private LoyaltyProgramId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static LoyaltyProgramId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static LoyaltyProgramId Create(string value)
    {
        return !Guid.TryParse(value, out Guid objGuid) ? new(objGuid) : new LoyaltyProgramId(objGuid);
    }
    public static LoyaltyProgramId Create(Guid value)
    {
        return new(value);
    }

    private LoyaltyProgramId()
    {
        
    }
    public override Guid Value { get; protected set; }
}