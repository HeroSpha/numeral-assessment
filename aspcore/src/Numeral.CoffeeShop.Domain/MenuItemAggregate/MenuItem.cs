

using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.MenuItemAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.Models;

namespace Numeral.CoffeeShop.Domain.MenuItemAggregate;

public sealed class MenuItem : AggregateRoot<MenuItemId, Guid>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Image { get; private set; }
    public decimal Price { get; private set;}
    public bool IsAvailable { get; private set;}
    public LoyaltyProgramId LoyaltyProgramId { get; private set;}

    private MenuItem(MenuItemId id, string name, string description, string image, decimal price, bool isAvailable, LoyaltyProgramId loyaltyProgramId) : base(id)
    {
        Name = name;
        Description = description;
        Image = image;
        Price = price;
        IsAvailable = isAvailable;
        LoyaltyProgramId = loyaltyProgramId;
    }

    public static MenuItem Create(
        string name,
        string description,
        decimal price,
        string image, bool isAvailable, LoyaltyProgramId loyaltyProgramId)
    {
        return new(MenuItemId.CreateUnique(), name, description, image,price, isAvailable, loyaltyProgramId);
    }
    
#pragma warning disable CS8618
    private MenuItem() {}
#pragma warning restore CS8618
}