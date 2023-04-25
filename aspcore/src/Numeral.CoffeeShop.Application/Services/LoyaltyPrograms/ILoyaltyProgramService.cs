using Numeral.CoffeeShop.Application.Services.LoyaltyPrograms.Dto;
using Numeral.CoffeeShop.Domain.CustomerAggregate.Entities;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.OrderAggregate.Entities;

namespace Numeral.CoffeeShop.Application.Services.LoyaltyPrograms;

public interface ILoyaltyProgramService
{
    Task<IEnumerable<RewardDto>> CalculateRewards(IEnumerable<LoyaltyProgramId> loyaltyProgramIds);
}