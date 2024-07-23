using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Patients.Commands;

namespace SaudeSemFronteiras.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] CreatePatientCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ChangePatient([FromBody] ChangePatientCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
