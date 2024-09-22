using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Emergencys.Commands;
using SaudeSemFronteiras.Application.Emergencys.Queries;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmergencyController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IEmergencyQueries _emergencyQueries;

    public EmergencyController(IMediator mediator, IEmergencyQueries emergencyQueries)
    {
        _mediator = mediator;
        _emergencyQueries = emergencyQueries;
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetScheduleByPatientId(long patientId, CancellationToken cancellationToken)
    {
        var emergencies = await _emergencyQueries.GetEmergenciesByPatientId(patientId, cancellationToken);

        return Ok(emergencies);
    }

    [HttpGet("lastEmergency/patient/{patientId}")]
    public async Task<IActionResult> GetLastAppointmentByPatient(long patientId, CancellationToken cancellationToken)
    {
        var appointment = await _emergencyQueries.GetLastEmergencyByPatientQuery(patientId, cancellationToken);

        return Ok(appointment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmergency([FromBody] CreateEmergencyCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ChangeEmergency([FromBody] ChangeEmergencyCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
