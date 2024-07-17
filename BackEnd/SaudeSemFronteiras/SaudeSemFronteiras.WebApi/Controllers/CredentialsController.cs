using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Login.Commands;
using SaudeSemFronteiras.Application.Login.Queries;
using SaudeSemFronteiras.Application.Users.Commands;
using SaudeSemFronteiras.WebApi.Authorizations;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CredentialsController(IMediator _mediator, ICredentialsQueries _credentialsQueries) : ControllerBase
{
    [HttpGet]
    [Authorization]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var users = await _credentialsQueries.GetAll(cancellationToken);

        return Ok(users);
    }

    [HttpPost]
    //[Authorization]
    public async Task<IActionResult> CreateCredentials([FromBody] CreateCredentialsCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    [Authorization]
    public async Task<IActionResult> ChangeCredentials([FromBody] ChangeCredentialsCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
