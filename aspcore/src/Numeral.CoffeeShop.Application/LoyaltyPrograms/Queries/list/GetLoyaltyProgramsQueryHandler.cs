using MediatR;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;

namespace Numeral.CoffeeShop.Application.LoyaltyPrograms.Queries.list;

public class GetLoyaltyProgramsQueryHandler : IRequestHandler<GetLoyaltyProgramsQuery, IEnumerable<LoyaltyProgram>>
{
    private readonly IRepository<LoyaltyProgram> _loyaltyProgramRepository;

    public GetLoyaltyProgramsQueryHandler(IRepository<LoyaltyProgram> loyaltyProgramRepository)
    {
        _loyaltyProgramRepository = loyaltyProgramRepository;
    }

    public async Task<IEnumerable<LoyaltyProgram>> Handle(GetLoyaltyProgramsQuery request, CancellationToken cancellationToken)
    {
        return await _loyaltyProgramRepository.GetAsync();
    }
}