using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace Numeral.CoffeeShop.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/error")]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        var (statusCode, message) = exception switch
        {
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
        };
        return Problem(title: message, statusCode: statusCode);
    }
}