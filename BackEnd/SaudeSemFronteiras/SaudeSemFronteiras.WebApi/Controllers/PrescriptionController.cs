using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Medicines.Commands;
using SaudeSemFronteiras.Application.Prescriptions.Commands;
using SaudeSemFronteiras.Application.Prescriptions.Queries;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IPrescriptionQueries _prescriptionQueries;

    public PrescriptionController(IMediator mediator, IPrescriptionQueries prescriptionQueries)
    {
        _mediator = mediator;
        _prescriptionQueries = prescriptionQueries;
    }

    [HttpGet("document/{documentId}")]
    public async Task<IActionResult> GetPrescriptionByDocumentId(long documentId, CancellationToken cancellationToken)
    {
        var prescription = await _prescriptionQueries.GetPrescriptionByDocumentIdQuery(documentId, cancellationToken);

        return Ok(prescription);
    }

    [HttpGet("id/{documentId}")]
    public async Task<IActionResult> GetPrescriptionIdByDocumentId(long documentId, CancellationToken cancellationToken)
    {
        var prescription = await _prescriptionQueries.GetPrescriptionIdByDocumentIdQuery(documentId, cancellationToken);

        return Ok(prescription);
    }

    [HttpGet("documentId/{documentId}")]
    public async Task<IActionResult> GetPrescriptionShowByDocumentIdQuery(long documentId, CancellationToken cancellationToken)
    {
        var prescription = await _prescriptionQueries.GetPrescriptionShowByDocumentIdQuery(documentId, cancellationToken);

        return Ok(prescription);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] CreatePrescriptionCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ChangePrescription([FromBody] ChangePrescriptionCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMedicine(long id, CancellationToken cancellationToken)
    {
        var command = new DeletePrescriptionCommand { Id = id };
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
