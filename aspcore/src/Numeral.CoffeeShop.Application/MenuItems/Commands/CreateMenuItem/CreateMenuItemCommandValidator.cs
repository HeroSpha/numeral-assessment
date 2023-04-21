using FluentValidation;

namespace Numeral.CoffeeShop.Application.MenuItems.Commands.CreateMenuItem;

public class CreateMenuItemCommandValidator : AbstractValidator<MenuItemCommand>
{
    public CreateMenuItemCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.Description)
            .NotEmpty();
        RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(x => x.LoyaltyProgramId)
            .NotNull();
    }
}