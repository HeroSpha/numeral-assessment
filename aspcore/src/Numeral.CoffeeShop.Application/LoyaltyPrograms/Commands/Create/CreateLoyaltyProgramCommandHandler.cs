using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;

namespace Numeral.CoffeeShop.Application.LoyaltyPrograms.Commands.Create;

public class CreateLoyaltyProgramCommandHandler : IRequestHandler<CreateLoyaltyProgramCommand, ErrorOr<LoyaltyProgram>>
{
    private readonly IRepository<LoyaltyProgram> _loyaltyProgramRepository;

    public CreateLoyaltyProgramCommandHandler(IRepository<LoyaltyProgram> loyaltyProgramRepository)
    {
        _loyaltyProgramRepository = loyaltyProgramRepository;
    }

    public async Task<ErrorOr<LoyaltyProgram>> Handle(CreateLoyaltyProgramCommand request, CancellationToken cancellationToken)
    {
        var loyaltyProgram = LoyaltyProgram.Create(request.PointConversionRate, request.PointRedemptionRate, request.Name);
        await _loyaltyProgramRepository.InsertAsync(loyaltyProgram);
        return loyaltyProgram;
    }
}