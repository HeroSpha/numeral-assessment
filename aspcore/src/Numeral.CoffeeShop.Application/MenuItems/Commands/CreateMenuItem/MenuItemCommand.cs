using MediatR;
using ErrorOr;
using Numeral.CoffeeShop.Domain.MenuItemAggregate;

namespace Numeral.CoffeeShop.Application.MenuItems.Commands.CreateMenuItem;

public record MenuItemCommand(
    string Name,
    string Description,
    string Image,
    decimal Price,
    bool IsAvailable,
    string LoyaltyProgramId) : IRequest<ErrorOr<MenuItem>>;