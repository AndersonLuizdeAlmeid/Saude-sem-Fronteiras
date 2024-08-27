using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Phones.Commands;
using SaudeSemFronteiras.Application.Phones.Queries;

namespace SaudeSemFronteiras.WebApi.Controllers;
[ApiController]
[Route("[controller]")]

public class PhoneController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IPhoneQueries _phoneQueries;

    public PhoneController(IMediator mediator, IPhoneQueries phoneQueries)
    {
        _mediator = mediator;
        _phoneQueries = phoneQueries;
    }

    [HttpGet]
    public async Task<IActionResult> GetById(long iD, CancellationToken cancellationToken)
    {
        var phones = _phoneQueries.GetById(iD, cancellationToken);
        return Ok(phones);
    }



    [HttpPost]
    public async Task<IActionResult> CreatePhone([FromBody] CreatePhoneCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> ChangePhone([FromBody] ChangePhoneCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (!result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result);
    }
}
