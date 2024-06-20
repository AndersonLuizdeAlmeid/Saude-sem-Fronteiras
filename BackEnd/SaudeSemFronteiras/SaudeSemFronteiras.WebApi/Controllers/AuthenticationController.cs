using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Authentications.Commands;
using SaudeSemFronteiras.WebApi.Authorizations;


namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticationCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpGet]
    [Authorization]
    public IActionResult ValidateToken()
    {
        return Ok();
    }
}
