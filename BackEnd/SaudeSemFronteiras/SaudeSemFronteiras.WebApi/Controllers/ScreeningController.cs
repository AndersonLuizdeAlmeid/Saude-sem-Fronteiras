using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Screenings.Commands;
using SaudeSemFronteiras.Application.Screenings.Queries;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ScreeningController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IScreeningQueries _screeningQueries;

    public ScreeningController(IMediator mediator, IScreeningQueries screeningQueries)
    {
        _mediator = mediator;
        _screeningQueries = screeningQueries;
    }

    [HttpGet("{emergencyId}")]
    public async Task<IActionResult> GetDataOfScreeningByEmergencyId(long emergencyId, CancellationToken cancellationToken)
    {
        var screening = await _screeningQueries.GetDataOfScreeningByEmergencyIdQuery(emergencyId, cancellationToken);
        if (screening == null)
            return Ok(null);

        return Ok(screening);
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
