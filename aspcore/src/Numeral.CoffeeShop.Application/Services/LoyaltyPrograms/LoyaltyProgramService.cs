
using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Application.Services.LoyaltyPrograms.Dto;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.MenuItemAggregate;
using Numeral.CoffeeShop.Domain.OrderAggregate.Entities;
namespace Numeral.CoffeeShop.Application.Services.LoyaltyPrograms;

public class LoyaltyProgramService : ILoyaltyProgramService
{
    private readonly IRepository<LoyaltyProgram> _loyaltyProgramRepository;
    private readonly IRepository<MenuItem> _menuItemsRepository;

    public LoyaltyProgramService(IRepository<LoyaltyProgram> loyaltyProgramRepository, IRepository<MenuItem> menuItemsRepository)
    {
        _loyaltyProgramRepository = loyaltyProgramRepository;
        _menuItemsRepository = menuItemsRepository;
    }

    public async Task<IEnumerable<RewardDto>> CalculateRewards(IEnumerable<LoyaltyProgramId> loyaltyProgramIds)
    {
        var list = new List<RewardDto>();
        var programs = await _loyaltyProgramRepository.GetAsync();
        var loyaltyPrograms = programs as LoyaltyProgram[] ?? programs.ToArray();
        
        foreach (var programId in loyaltyProgramIds)
        {
            var program = loyaltyPrograms.FirstOrDefault(x => x.Id == programId);
            if (program == null)
            {
                continue;
            }
            var reward = new RewardDto(program!.Name, program.PointRedemptionRate, program.PointConversionRate);
            list.Add(reward);
        }

        return list;
    }
}