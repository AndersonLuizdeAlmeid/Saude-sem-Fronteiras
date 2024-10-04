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

    [HttpGet("id/{appointmentId}")]
    public async Task<IActionResult> GetByAppointmentId(long appointmentId, CancellationToken cancellationToken)
    {
        var phone = _appointmentQueries.GetByAppointmentIdQuery(appointmentId, cancellationToken);

        return Ok(phone.Result);
    }

    [HttpGet("patient/phone/{appointmentId}/{patientId}")]
    public async Task<IActionResult> GetPhoneByPatient(long appointmentId, long patientId, CancellationToken cancellationToken)
    {
        var phone = _appointmentQueries.GetPhoneByPatient(appointmentId, patientId, cancellationToken);

        return Ok(phone.Result);
    }

    [HttpGet("dateAppointment/emergencyId/{emergencyId}")]
    public async Task<IActionResult> GetDateByEmergencyId(long emergencyId, CancellationToken cancellationToken)
    {
        var dateString = await _appointmentQueries.GetDateByEmergencyIdQuery(emergencyId, cancellationToken);

        return Ok(dateString);
    }

    [HttpGet("scheduled/validation/{scheduleId}")]
    public async Task<IActionResult> ValidateDateToAppointmentScheduled(long scheduleId, CancellationToken cancellationToken)
    {
        var canStartAppointment = await _appointmentQueries.ValidateDateToAppointmentScheduledQuery(scheduleId, cancellationToken);

        return Ok(canStartAppointment);
    }

    [HttpGet("emergency/validation/{emergencyId}")]
    public async Task<IActionResult> ValidateDateToAppointmentEmergency(long emergencyId, CancellationToken cancellationToken)
    {
        var canStartAppointment = await _appointmentQueries.ValidateDateToAppointmentEmergencyQuery(emergencyId, cancellationToken);

        return Ok(canStartAppointment);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetAppointmentsByPatientId(long patientId, CancellationToken cancellationToken)
    {
        var patientIdByAppointment = await _appointmentQueries.GetAppointmentsByPatientId(patientId, cancellationToken);

        return Ok(patientIdByAppointment);
    }

    [HttpGet("patientId/{id}")]
    public async Task<IActionResult> GetPatientIdByAppointmentId(long id, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentQueries.GetPatientIdByAppointmentId(id, cancellationToken);

        return Ok(appointment);
    }

    [HttpGet("lastAppointment/patient/{patientId}")]
    public async Task<IActionResult> GetLastAppointmentByPatient(long patientId, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentQueries.GetLastAppointmentByPatientQuery(patientId, cancellationToken);

        return Ok(appointment);
    }

    [HttpGet("doctor/{doctorId}")]
    public async Task<IActionResult> GetAppointmentsByDoctorId(long doctorId, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentQueries.GetAppointmentsByDoctorId(doctorId, cancellationToken);

        return Ok(appointments);
    }

    [HttpGet("doctorPatient/{doctorId}/{patientId}")]
    public async Task<IActionResult> GetAppointmentIdByDoctorIdAndPatientId(long doctorId, long patientId, CancellationToken cancellationToken)
    {
        var appointmentId = await _appointmentQueries.GetLastAppointmentByPatientAndDoctor(doctorId, patientId, cancellationToken);

        return Ok(appointmentId);
    }

    [HttpGet("doctor/patient/{doctorId}/{patientId}")]
    public async Task<IActionResult> GetAppointmentsByDoctorAndPatientId(long doctorId, long patientId, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentQueries.GetAppointmentsByDoctorAndPatientIdQuery(doctorId, patientId, cancellationToken);

        return Ok(appointments);
    }

    [HttpGet("patients/doctor/{doctorId}")]
    public async Task<IActionResult> GetPatientsOfAppointmentsByDoctor(long doctorId, CancellationToken cancellationToken)
    {
        var appointmentId = await _appointmentQueries.GetPatientsOfAppointmentsByDoctorQuery(doctorId, cancellationToken);

        return Ok(appointmentId);
    }

    [HttpGet("emergencyId/{emergencyId}")]
    public async Task<IActionResult> GetAppointmentByEmergencyId(long emergencyId, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentQueries.GetAppointmentByEmergencyIdQuery(emergencyId, cancellationToken);

        return Ok(appointment);
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteAppointmentCommand { Id = id };
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
