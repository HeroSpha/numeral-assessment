using MediatR;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Domain.MenuItemAggregate;

namespace Numeral.CoffeeShop.Application.MenuItems.Queries.List;

public class GetMenuItemsQueryHandler : IRequestHandler<GetMenuItemsQuery, IEnumerable<MenuItem>>
{
    private readonly IRepository<MenuItem> _menuRepository;

    public GetMenuItemsQueryHandler(IRepository<MenuItem> menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<IEnumerable<MenuItem>> Handle(GetMenuItemsQuery request, CancellationToken cancellationToken)
    {
        return await _menuRepository.GetAsync();
    }
}