using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Appointments.Commands;
using SaudeSemFronteiras.Application.Appointments.Queries;
using SaudeSemFronteiras.Application.Appointments.Services;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly AppointmentsService _appointmentsService;
    private readonly IAppointmentQueries _appointmentQueries;

    public AppointmentController(IMediator mediator, AppointmentsService appointmentsService, IAppointmentQueries appointmentQueries)
    {
        _mediator = mediator;
        _appointmentsService = appointmentsService;
        _appointmentQueries = appointmentQueries;
    }

    [HttpGet("freeTime/{doctor_id}/{date}")]
    public async Task<IActionResult> GetAllFreeTimeByDoctor(long doctor_id, string date, CancellationToken cancellationToken)
    {
        DateOnly parsedDate;
        if (!DateOnly.TryParse(date, out parsedDate))
        {
            return BadRequest("Invalid date format. Expected yyyy-MM-dd.");
        }

        var free_time = _appointmentsService.GetAllFreeTimeOfAppointmentsByDoctor(doctor_id, parsedDate, cancellationToken);

        return Ok(free_time);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetAppointmentsByPatientId(long patientId, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentQueries.GetAppointmentsByPatientId(patientId, cancellationToken);

        return Ok(appointments);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ChangeAppointment([FromBody] ChangeAppointmentCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
