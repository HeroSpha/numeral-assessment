using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Application.LoyaltyPrograms.Queries.Get;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate.ValueObjects;

namespace Numeral.CoffeeShop.Application.LoyaltyPrograms.Queries.Get;

public class GetLoyaltyProgramQueryHandler : IRequestHandler<GetLoyaltyProgramQuery, ErrorOr<LoyaltyProgram>>
{
    private readonly IRepository<LoyaltyProgram> _loyaltyProgramRepository;

    public GetLoyaltyProgramQueryHandler(IRepository<LoyaltyProgram> loyaltyProgramRepository)
    {
        _loyaltyProgramRepository = loyaltyProgramRepository;
    }

    public async Task<ErrorOr<LoyaltyProgram>> Handle(GetLoyaltyProgramQuery request, CancellationToken cancellationToken)
    {
        var loyaltyProgram = await _loyaltyProgramRepository.GetByIdAsync(LoyaltyProgramId.Create(request.LoyaltyProgramId));
        return loyaltyProgram;
    }
}