using FluentValidation;

namespace Numeral.CoffeeShop.Application.LoyaltyPrograms.Queries.Get;

public class GetLoyaltyProgramQueryValidator : AbstractValidator<GetLoyaltyProgramQuery>
{
    public GetLoyaltyProgramQueryValidator()
    {
        RuleFor(x => x.LoyaltyProgramId)
            .NotEmpty();
    }
}