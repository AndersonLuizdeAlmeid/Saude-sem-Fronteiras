using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Screenings.Commands;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ScreeningController : ControllerBase
{
    private readonly IMediator _mediator;

    public ScreeningController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateScreening([FromBody] CreateScreeningCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ChangeScreening([FromBody] ChangeScreeningCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
