using Numeral.CoffeeShop.Domain.CustomerAggregate.Enums;
using Numeral.CoffeeShop.Domain.CustomerAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.Models;

namespace Numeral.CoffeeShop.Domain.CustomerAggregate.Entities;

public sealed class Reward : Entity<RewardId>
{
    public CustomerRewardEnum CustomerRewardEnum { get; private set; }
    public string ProgramName { get; private set; }
    public decimal CashValue { get; private set; }
    public double Points { get; private set; }

    private Reward(
        RewardId id,
        string programName,
        CustomerRewardEnum customerRewardEnum,
        decimal cashValue,
        double points) : base(id)
    {
        ProgramName = programName;
        CustomerRewardEnum = customerRewardEnum;
        CashValue = cashValue;
        Points = points;
    }

    internal void Redeem()
    {
        CustomerRewardEnum = CustomerRewardEnum.Redeemed;
    }

#pragma warning disable CS8618
    private Reward() {}
#pragma warning restore CS8618

    public static Reward Create(string programName, 
        CustomerRewardEnum customerRewardEnum, 
        decimal cashValue,
        double points)
    {
        return new(RewardId.CreateUnique(), programName, customerRewardEnum, cashValue, points);
    }
}