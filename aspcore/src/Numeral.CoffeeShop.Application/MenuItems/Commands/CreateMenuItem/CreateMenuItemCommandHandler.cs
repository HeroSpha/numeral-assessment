using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.MenuItemAggregate;

namespace Numeral.CoffeeShop.Application.MenuItems.Commands.CreateMenuItem;

public class CreateMenuItemCommandHandler : IRequestHandler<MenuItemCommand, ErrorOr<MenuItem>>
{
    private readonly IRepository<MenuItem> _menuItemRepository;

    public CreateMenuItemCommandHandler(IRepository<MenuItem> menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }
    public async Task<ErrorOr<MenuItem>> Handle(MenuItemCommand request, CancellationToken cancellationToken)
    {
        //create menuItem
        var menuItem = MenuItem.Create(
            request.Name,
            request.Description,
            request.Price,
            request.Image,
            request.IsAvailable,
             LoyaltyProgramId.Create(request.LoyaltyProgramId));
        //persist menuItem
         await _menuItemRepository.InsertAsync(menuItem);
        //return menuItem
        return menuItem;
    }
}