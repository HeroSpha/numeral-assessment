using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Numeral.CoffeeShop.Api.Contracts.Customers;
using Numeral.CoffeeShop.Application.Customers.Commands;
using Numeral.CoffeeShop.Application.Customers.Queries;
using Numeral.CoffeeShop.Application.Customers.Queries.List;
using Numeral.CoffeeShop.Domain.CustomerAggregate;

namespace Numeral.CoffeeShop.Api.Controllers;

[Route("customers")]
public class CustomersController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public CustomersController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetCustomer(string id)
    {
        var query = new GetCustomerQuery(id);
        var customerResult = await _mediator.Send(query);
        return customerResult.Match(
            resp => Ok(_mapper.Map<CustomerResponse>(resp)),
            Problem);
    }
    
    [HttpGet("getcustomer")]
    public async Task<IActionResult> GetCustomer()
    {
        (string role, string? userId) = GetUser();
        if (string.IsNullOrEmpty(userId))
        {
            return Problem();
        }
        var query = new GetCustomerQuery(userId);
        var customerResult = await _mediator.Send(query);
        return customerResult.Match(
            resp => Ok(_mapper.Map<CustomerResponse>(resp)),
            Problem);
    }
    
    [HttpGet("redeem")]
    public async Task<IActionResult> Redeem()
    {
        (string role, string? userId) = GetUser();
        if (string.IsNullOrEmpty(userId))
        {
            return Problem();
        }
        var query = new RedeemCommand(userId);
        var customerResult = await _mediator.Send(query);
        return customerResult.Match(
            resp => Ok(_mapper.Map<CustomerResponse>(resp)),
            Problem);
    }
    
    [HttpGet()]
    public async Task<IActionResult> GetCustomers()
    {
        var query = new GetCustomersQuery();
        var customerResult = await _mediator.Send(query);
        return Ok(_mapper.Map<IEnumerable<CustomerResponse>>(customerResult));
    }
}