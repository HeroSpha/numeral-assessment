using FluentValidation;

namespace Numeral.CoffeeShop.Application.Orders.Commands.Create;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.MenuItems.Count())
            .GreaterThan(0);
    }
}