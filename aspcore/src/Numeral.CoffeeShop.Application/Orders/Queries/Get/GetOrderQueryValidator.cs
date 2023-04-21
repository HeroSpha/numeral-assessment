using FluentValidation;

namespace Numeral.CoffeeShop.Application.Orders.Queries.Get;

public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
{
    public GetOrderQueryValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty();
    }
}