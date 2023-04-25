using Numeral.CoffeeShop.Domain.CustomerAggregate.Entities;
using Numeral.CoffeeShop.Domain.CustomerAggregate.Enums;
using Numeral.CoffeeShop.Domain.CustomerAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.MenuItemAggregate;
using Numeral.CoffeeShop.Domain.Models;

namespace Numeral.CoffeeShop.Domain.CustomerAggregate;

public sealed class Customer : AggregateRoot<CustomerId, Guid>
{
    public double Points { get; private set; }
    public decimal Cash { get; private set; }
    private readonly List<Reward> _rewards;
    public IReadOnlyList<Reward> Rewards => _rewards.AsReadOnly();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    private Customer(CustomerId id, string firstName, string lastName, string email) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        _rewards = new List<Reward>();
        Cash = 0;
        CalculatePoints();
    }

    private void CalculatePoints()
    {
        Points = _rewards.Where(x => x.CustomerRewardEnum == CustomerRewardEnum.Earned).Sum(x => x.Points);
    }

    public Customer AddRewards(IEnumerable<Reward> rewards)
    {
        _rewards.AddRange(rewards);
        CalculatePoints();
        return this;
    }
    public static Customer Create(Guid id, string firstName, string lastName, string email)
    {
        return new(CustomerId.Create(id), firstName, lastName, email);
    }
    
#pragma warning disable CS8618
    private Customer() {}
#pragma warning restore CS8618


    public void RedeemPoints()
    {
        foreach (var reward in _rewards.Where(x => x.CustomerRewardEnum == CustomerRewardEnum.Earned))
        {
            Cash += reward.CashValue;
            reward.Redeem();
        }
        Points = 0;
    }
}