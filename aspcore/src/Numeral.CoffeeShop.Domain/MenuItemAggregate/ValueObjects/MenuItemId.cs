using Numeral.CoffeeShop.Domain.Models;

namespace Numeral.CoffeeShop.Domain.MenuItemAggregate.ValueObjects;

public sealed class MenuItemId : AggregateRootId<Guid>
{
    //public Guid Value { get; }
    private MenuItemId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid value)
    {
        return new(value);
    }
    public static MenuItemId Create(string value)
    {
        return !Guid.TryParse(value, out Guid objGuid) ? new(objGuid) : new MenuItemId(objGuid);
    }

    private MenuItemId()
    {
        
    }

    public override Guid Value { get; protected set; }
}