using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Patients.Commands;
using SaudeSemFronteiras.Application.Patients.Queries;

namespace SaudeSemFronteiras.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IPatientQueries _patientQueries;

    public PatientController(IMediator mediator, IPatientQueries patientQueries)
    {
        _mediator = mediator;
        _patientQueries = patientQueries;
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetPatientByUserCode(long iD, CancellationToken cancellationToken)
    {
        var patient = _patientQueries.GetByUserId(iD, cancellationToken);
        if (patient == null)
            return BadRequest("Endereço não encontrado.");

        return Ok(patient.Result);
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
