using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Doctors.Commands;
using SaudeSemFronteiras.Application.Doctors.Queries;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IDoctorQueries _doctorQueries;

    public DoctorController(IMediator mediator, IDoctorQueries doctorQueries)
    {
        _mediator = mediator;
        _doctorQueries = doctorQueries;
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetDoctorByUserCode(long iD, CancellationToken cancellationToken)
    {
        var doctor = await _doctorQueries.GetByUserId(iD, cancellationToken);
        if (doctor == null)
            return BadRequest("Médico não encontrado.");

        return Ok(doctor);
    }

    [HttpGet("doctorId/{doctorId}")]
    public async Task<IActionResult> GetDoctorById(long doctorId, CancellationToken cancellationToken)
    {
        var doctor = await _doctorQueries.GetDtoById(doctorId, cancellationToken);
        if (doctor == null)
            return BadRequest("Médico não encontrado.");

        return Ok(doctor);
    }

    [HttpGet("price/{doctorId}")]
    public async Task<IActionResult> GetPriceByDoctorId(long doctorId, CancellationToken cancellationToken)
    {
        var doctor = await _doctorQueries.GetPriceByDoctorIdQuery(doctorId, cancellationToken);
        if (doctor == null)
            return BadRequest("Médico não encontrado.");

        return Ok(doctor);
    }

    [HttpGet("specialityId/{speciality_id}")]
    public async Task<IActionResult> GetDoctorsBySpeciality(long speciality_id, CancellationToken cancellationToken)
    {
        var doctor = await _doctorQueries.GetAllDoctorsBySpeciality(speciality_id, cancellationToken);
        if (doctor == null)
            return BadRequest("Médico não encontrado.");

        return Ok(doctor);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ChangeDoctor([FromBody] ChangeDoctorCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
