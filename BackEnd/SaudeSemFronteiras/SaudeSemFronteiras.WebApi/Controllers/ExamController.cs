using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Exams.Commands;
using SaudeSemFronteiras.Application.Exams.Queries;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExamController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IExamQueries _examQueries;

    public ExamController(IMediator mediator, IExamQueries examQueries)
    {
        _mediator = mediator;
        _examQueries = examQueries;
    }

    [HttpGet("document/{documentId}")]
    public async Task<IActionResult> GetExamByDocumentId(long documentId, CancellationToken cancellationToken)
    {
        var exam = await _examQueries.GetExamByDocumentIdQuery(documentId, cancellationToken);

        return Ok(exam);
    }

    [HttpPost]
    public async Task<IActionResult> CreateExam([FromBody] CreateExamCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ChangeExam([FromBody] ChangeExamCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
