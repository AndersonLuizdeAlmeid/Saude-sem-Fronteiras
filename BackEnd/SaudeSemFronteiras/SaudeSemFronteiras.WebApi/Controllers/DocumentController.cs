using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Documents.Commands;
using SaudeSemFronteiras.Application.Documents.Queries;
using SaudeSemFronteiras.Application.Specialities.Commands;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DocumentController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IDocumentQueries _documentQueries;

    public DocumentController(IMediator mediator, IDocumentQueries documentQueries)
    {
        _mediator = mediator;
        _documentQueries = documentQueries;
    }

    [HttpGet("doctor/{doctorId}")]
    public async Task<IActionResult> GetDocumentsByDoctorId(long doctorId, CancellationToken cancellationToken)
    {
        var documents = _documentQueries.GetDocumentsByDoctorIdQuery(doctorId, cancellationToken);

        return Ok(documents.Result);
    }

    [HttpGet("patient/{doctorId}")]
    public async Task<IActionResult> GetDocumentsByPatientId(long doctorId, CancellationToken cancellationToken)
    {
        var documentId = _documentQueries.GetDocumentsByPatientIdQuery(doctorId, cancellationToken);

        return Ok(documentId.Result);
    }

    [HttpGet("last/{appointmentId}")]
    public async Task<IActionResult>GetLastDocumentIdByAppointmentId(long appointmentId, CancellationToken cancellationToken)
    {
        var documentId = _documentQueries.GetLastDocumentIdByAppointmentIdQuery(appointmentId, cancellationToken);

        return Ok(documentId.Result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDocument([FromBody] CreateDocumentCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ChangeDocument([FromBody] ChangeDocumentCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDocument(long id, CancellationToken cancellationToken)
    {
        var command = new DeleteDocumentCommand { Id = id };
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
