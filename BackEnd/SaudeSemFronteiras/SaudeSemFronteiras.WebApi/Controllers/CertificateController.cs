using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Certificates.Commands;
using SaudeSemFronteiras.Application.Certificates.Queries;
using SaudeSemFronteiras.Application.Documents.Commands;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CertificateController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICertificateQueries _certificateQueries;

    public CertificateController(IMediator mediator, ICertificateQueries certificateQueries)
    {
        _mediator = mediator;
        _certificateQueries = certificateQueries;
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetByIdDto(long id, CancellationToken cancellationToken)
    {
        var certificate = await _certificateQueries.GetByIdDtoQuery(id, cancellationToken);

        return Ok(certificate);
    }

    [HttpGet("document/{documentId}")]
    public async Task<IActionResult> GetCertificateByDocumentId(long documentId, CancellationToken cancellationToken)
    {
        var certificate = await _certificateQueries.GetCertificateByDocumentIdQuery(documentId, cancellationToken);

        return Ok(certificate);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCertificate([FromBody] CreateCertificateCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ChangeCertificate([FromBody] ChangeCertificateCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCertificate(long id, CancellationToken cancellationToken)
    {
        var command = new DeleteCertificateCommand { Id = id };
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
