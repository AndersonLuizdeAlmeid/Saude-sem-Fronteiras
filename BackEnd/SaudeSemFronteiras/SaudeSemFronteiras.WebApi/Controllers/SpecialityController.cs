using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Specialities.Commands;
using SaudeSemFronteiras.Application.Specialities.Queries;

namespace SaudeSemFronteiras.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class SpecialityController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ISpecialityQueries _specialityQueries;

    public SpecialityController(IMediator mediator, ISpecialityQueries specialityQueries)
    {
        _mediator = mediator;
        _specialityQueries = specialityQueries;
    }

    [HttpGet("{doctorId}")]
    public async Task<IActionResult> GetById(long doctorId, CancellationToken cancellationToken)
    {
        var specialities = await _specialityQueries.GetAllSpecialitiesByDoctorId(doctorId, cancellationToken);
        return Ok(specialities);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll(long doctorId, CancellationToken cancellationToken)
    {
        var specialities = await _specialityQueries.GetAll(cancellationToken);
        return Ok(specialities);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSpeciality([FromBody] CreateSpecialityCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ChangeSpeciality([FromBody] ChangeSpecialityCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (!result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhone(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteSpecialityCommand { Id = id };
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
