using FluentValidation;

using MediatR;

namespace Numeral.CoffeeShop.Application.Customers.Queries;

public class GetCustomerQueryValidator : AbstractValidator<GetCustomerQuery>
{
    public GetCustomerQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}