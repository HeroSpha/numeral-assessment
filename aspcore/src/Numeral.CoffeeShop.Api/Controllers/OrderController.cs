using System.Security.Claims;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Numeral.CoffeeShop.Api.Contracts.Orders;
using Numeral.CoffeeShop.Application.Orders.Commands.Create;
using Numeral.CoffeeShop.Application.Orders.Queries.Get;
using Numeral.CoffeeShop.Application.Orders.Queries.list;

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
    [Authorize(Roles = "Customer")]
    public async Task<IActionResult> Create(CreateOrderRequest request)
    {
        (string role, string? userId) = GetUser();
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest();
        }

        var command = new CreateOrderCommand(_mapper.Map<IEnumerable<OrderItemDto>>(request.OrderItems), userId);
        var orderResult = await _mediator.Send(command);
        return orderResult.Match(
            menuItem => Ok(_mapper.Map<OrderResponse>(menuItem)),
            Problem);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }

    [HttpGet("id")]
    [Authorize(Roles = "Customer")]
    public async Task<IActionResult> GetOrderById(string id)
    {
        var query = _mapper.Map<GetOrderQuery>(id);
        var orderResult = await _mediator.Send(query);
        return orderResult.Match(
            menuItem => Ok(_mapper.Map<OrderResponse>(menuItem)),
            Problem);
    }
    
    [HttpGet("getorders")]
    [Authorize(Roles = "Customer")]
    public async Task<IActionResult> GetOrders()
    {
        (string role, string? userId) = GetUser();
        var query = new GetOrderListQuery(userId);
        var orderResult = await _mediator.Send(query);
        return Ok(_mapper.Map<IEnumerable<OrderResponse>>(orderResult));
    }
}