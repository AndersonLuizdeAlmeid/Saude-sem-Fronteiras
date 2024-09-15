using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SaudeSemFronteiras.Application.Login.Commands;
using SaudeSemFronteiras.Application.Login.Queries;
using SaudeSemFronteiras.Application.Login.Services;
using SaudeSemFronteiras.WebApi.Authorizations;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CredentialsController(IMediator _mediator, ICredentialsQueries _credentialsQueries) : ControllerBase
{
    [HttpGet("{email}/{password}")]
    public async Task<IActionResult> GetCredentialsByEmailAndPassword(string email, string password, CancellationToken cancellationToken)
    {
        var credentials = await _credentialsQueries.GetCredentialsByEmailAndPassword(email, password, cancellationToken);

        return Ok(credentials);
    }

    [HttpGet("RecoveryPassword/{email}")]
    public async Task<IActionResult> RecoveryPassword(string email, CancellationToken cancellationToken)
    {
        var result = CredentialsService.SendConfirmationEmail(email, cancellationToken);
        if (result.IsNullOrEmpty())
            return BadRequest();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCredentials([FromBody] CreateCredentialsCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut("Password")]
    public async Task<IActionResult> ChangeCredentialsByPassword([FromBody] ChangePasswordCommand command, CancellationToken cancellationToken)
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
