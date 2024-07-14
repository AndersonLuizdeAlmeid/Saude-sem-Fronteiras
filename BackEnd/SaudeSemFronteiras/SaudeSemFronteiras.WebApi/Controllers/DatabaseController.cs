using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Database.Commands;

namespace SaudeSemFronteiras.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class DatabaseController : ControllerBase
{
    private readonly IMediator _mediator;

    public DatabaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTables(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateTablesCommand(), cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
