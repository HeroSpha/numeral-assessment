using MapsterMapper;

using MediatR;
using ErrorOr;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Numeral.CoffeeShop.Api.Contracts.MenuItems;
using Numeral.CoffeeShop.Application.MenuItems.Commands.CreateMenuItem;
using Numeral.CoffeeShop.Application.MenuItems.Queries.List;
using Numeral.CoffeeShop.Domain.MenuItemAggregate;

namespace Numeral.CoffeeShop.Api.Controllers;
[Route("menuitems")]
public class MenuItemsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    public MenuItemsController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateMenuItem(CreateMenuItemRequest request)
    {
        var command = _mapper.Map<MenuItemCommand>(request);
        ErrorOr<MenuItem> menuItemResult = await _mediator.Send(
            command);
        return menuItemResult.Match(
            menuItem => Ok(_mapper.Map<MenuItemResponse>(menuItem)),
            Problem);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> ListMenuItems()
    {
        var query = new GetMenuItemsQuery();
        var result = await _mediator.Send(query);
        return Ok(_mapper.Map<IEnumerable<MenuItemResponse>>(result));
    }
}