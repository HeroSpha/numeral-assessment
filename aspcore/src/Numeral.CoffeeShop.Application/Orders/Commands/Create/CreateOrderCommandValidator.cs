using FluentValidation;

namespace Numeral.CoffeeShop.Application.Orders.Commands.Create;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.OrderItems.Count())
            .GreaterThan(0);
    }
}