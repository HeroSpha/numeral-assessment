
using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Application.Services.LoyaltyPrograms.Dto;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;
using Numeral.CoffeeShop.Domain.OrderAggregate.Entities;
namespace Numeral.CoffeeShop.Application.Services.LoyaltyPrograms;

public class LoyaltyProgramService : ILoyaltyProgramService
{
    private readonly IRepository<LoyaltyProgram> _loyaltyProgramRepository;

    public LoyaltyProgramService(IRepository<LoyaltyProgram> loyaltyProgramRepository)
    {
        _loyaltyProgramRepository = loyaltyProgramRepository;
    }

    public async Task<IEnumerable<RewardDto>> CalculateRewards(IEnumerable<OrderItem> orderItems)
    {
        var list = new List<RewardDto>();
        var programs = await _loyaltyProgramRepository.GetAsync();
        var loyaltyPrograms = programs as LoyaltyProgram[] ?? programs.ToArray();
        foreach (var orderItem in orderItems)
        {
            var program = loyaltyPrograms.FirstOrDefault(x => x.Id == orderItem.Id);
            var reward = new RewardDto(program!.Name, program.PointRedemptionRate, program.PointConversionRate);
            list.Add(reward);
        }

        return list;
    }
}