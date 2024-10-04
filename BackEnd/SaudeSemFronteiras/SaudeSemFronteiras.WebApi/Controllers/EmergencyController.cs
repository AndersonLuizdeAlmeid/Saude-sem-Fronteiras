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

    [HttpGet("doctor/{doctorId}")]
    public async Task<IActionResult> GetEmergenciesByDoctorId(long doctorId, CancellationToken cancellationToken)
    {
        var patientIdByAppointment = await _emergencyQueries.GetEmergenciesByDoctorIdQuery(doctorId, cancellationToken);

        return Ok(patientIdByAppointment);
    }

    [HttpGet("patient/list/{patientId}")]
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

    [HttpGet("patient/phone/{emergencyId}")]
    public async Task<IActionResult> GetPhoneByPatient(long emergencyId, CancellationToken cancellationToken)
    {
        var phone = _emergencyQueries.GetPhoneByPatientQuery(emergencyId, cancellationToken);

        return Ok(phone.Result);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetAppointmentByEmergencyId(long patientId, CancellationToken cancellationToken)
    {
        var emergencies = await _emergencyQueries.GetAppointmentByEmergencyIdQuery(patientId, cancellationToken);

        return Ok(emergencies);
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
