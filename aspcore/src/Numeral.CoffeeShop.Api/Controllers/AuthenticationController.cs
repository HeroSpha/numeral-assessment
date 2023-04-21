using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Numeral.CoffeeShop.Api.Contracts.Authentication;
using Numeral.CoffeeShop.Application.Authentication.Commands.Register;
using Numeral.CoffeeShop.Application.Authentication.Common;
using Numeral.CoffeeShop.Application.Authentication.Queries.Get;
using Numeral.CoffeeShop.Application.Authentication.Queries.GetUser;
using Numeral.CoffeeShop.Application.Authentication.Queries.Login;
using Numeral.CoffeeShop.Domain.Common.Errors;

namespace Numeral.CoffeeShop.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(
            command);
        return authResult.Match(
            auth => Ok(_mapper.Map<AuthenticationResponse>(auth)),
            Problem);
    }
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var loginQuery = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(
            loginQuery);
        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }
        return authResult.Match(
            auth => Ok(_mapper.Map<AuthenticationResponse>(auth)),
             Problem);
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetAll()
    {
        var command = new GetUserListCommand();
        var response = await _mediator.Send(
            command);
        var data = _mapper.Map<IEnumerable<GetUserResponse>>(response);
        return Ok(data);
    }
    
    [HttpGet("users/{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var command = new GetUserCommand(id);
        var response = await _mediator.Send(
            command);
        
        return response.Match(
            resp => Ok(_mapper.Map<GetUserResponse>(resp)),
                Problem);
    }
}