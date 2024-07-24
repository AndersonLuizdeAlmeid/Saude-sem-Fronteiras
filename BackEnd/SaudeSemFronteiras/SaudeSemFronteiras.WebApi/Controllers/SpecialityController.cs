using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Specialities.Commands;

namespace SaudeSemFronteiras.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class SpecialityController : ControllerBase
{
    private readonly IMediator _mediator;

    public SpecialityController(IMediator mediator)
    {
        _mediator = mediator; 
    }

    [HttpPost]
    public async Task<IActionResult> CreateSpeciality([FromBody] CreateSpecialityCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> ChangeSpeciality([FromBody] ChangeSpecialityCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (!result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result);
    }
}
