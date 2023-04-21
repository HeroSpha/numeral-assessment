using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Numeral.CoffeeShop.Api.Contracts.Orders;
using Numeral.CoffeeShop.Application.Orders.Commands.Create;
using Numeral.CoffeeShop.Application.Orders.Queries.Get;

namespace Numeral.CoffeeShop.Api.Controllers;
[Route("orders")]
public class OrderController  : ApiController
{
    private readonly ISender _mediator;

    private readonly IMapper _mapper;
    public OrderController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderRequest request)
    {
        var command = _mapper.Map<CreateOrderCommand>(request);
        var orderResult = await _mediator.Send(command);
        return orderResult.Match(
            menuItem => Ok(_mapper.Map<OrderResponse>(menuItem)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }

    [HttpGet("orderId")]
    public async Task<IActionResult> GetOrderById(string orderId)
    {
        var query = _mapper.Map<GetOrderQuery>(orderId);
        var orderResult = await _mediator.Send(query);
        return orderResult.Match(
            menuItem => Ok(_mapper.Map<OrderResponse>(menuItem)),
            Problem);
    }
}