using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Scheduled.Commands;
using SaudeSemFronteiras.Application.Scheduled.Queries;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IScheduleQueries _scheduleQueries;

    public ScheduleController(IMediator mediator, IScheduleQueries scheduleQueries)
    {
        _mediator = mediator;
        _scheduleQueries = scheduleQueries;
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetScheduleByPatientId(long patientId, CancellationToken cancellationToken)
    {
        var patientIdByAppointment = await _scheduleQueries.GetAppointmentsByPatientId(patientId, cancellationToken);

        return Ok(patientIdByAppointment);
    }

    [HttpGet("doctor/{doctorId}")]
    public async Task<IActionResult> GetScheduleByDoctorId(long doctorId, CancellationToken cancellationToken)
    {
        var patientIdByAppointment = await _scheduleQueries.GetAppointmentsByDoctorId(doctorId, cancellationToken);

        return Ok(patientIdByAppointment);
    }

    [HttpGet("doctor/phone/{scheduleId}")]
    public async Task<IActionResult> GetPhoneByDoctor(long scheduleId, CancellationToken cancellationToken)
    {
        var phone = await _scheduleQueries.GetPhoneByDoctorQuery(scheduleId, cancellationToken);

        return Ok(phone);
    }

    [HttpGet("patient/phone/{scheduleId}")]
    public async Task<IActionResult> GetPhoneByPatient(long scheduleId, CancellationToken cancellationToken)
    {
        var phone = await _scheduleQueries.GetPhoneByPatientQuery(scheduleId, cancellationToken);

        return Ok(phone);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSchedule([FromBody] CreateScheduleCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ChangeSchedule([FromBody] ChangeScheduleCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
