using MediatR;

using Numeral.CoffeeShop.Domain.MenuItemAggregate;

namespace Numeral.CoffeeShop.Application.MenuItems.Queries.List;

public record GetMenuItemsQuery(): IRequest<IEnumerable<MenuItem>>;