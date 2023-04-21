using ErrorOr;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Numeral.CoffeeShop.Api.Contracts.LoyaltyProgram;
using Numeral.CoffeeShop.Application.LoyaltyPrograms.Commands.Create;
using Numeral.CoffeeShop.Application.LoyaltyPrograms.Queries.Get;
using Numeral.CoffeeShop.Application.LoyaltyPrograms.Queries.list;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;

namespace Numeral.CoffeeShop.Api.Controllers;
[Route("loyaltyprograms")]
public class LoyaltyProgramControllers : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public LoyaltyProgramControllers(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add(CreateLoyaltyProgramRequest request)
    {
        var command = _mapper.Map<CreateLoyaltyProgramCommand>(request);
        ErrorOr<LoyaltyProgram> loyaltyProgramResult = await _mediator.Send(command);
        return loyaltyProgramResult.Match(
            loyaltyProgram => Ok(_mapper.Map<LoyaltyProgramResponse>(loyaltyProgram)),
            Problem);
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetLoyaltyById(string id)
    {
        var query = _mapper.Map<GetLoyaltyProgramQuery>(id);
        var loyaltyProgramResult = await _mediator.Send(query);
        return loyaltyProgramResult.Match(
            loyaltyProgram => Ok(_mapper.Map<LoyaltyProgramResponse>(loyaltyProgram)),
            Problem);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetLoyaltyPrograms()
    {
        var query = new GetLoyaltyProgramsQuery();
        var results = await _mediator.Send(query);
        return Ok(_mapper.Map<IEnumerable<LoyaltyProgramResponse>>(results));
    }
}