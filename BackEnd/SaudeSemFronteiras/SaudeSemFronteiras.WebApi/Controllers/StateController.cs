using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.States.Queries;

namespace SaudeSemFronteiras.WebApi.Controllers;
[ApiController]
[Route("[controller]")]

public class StateController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IStateQueries _stateQueries;

    public StateController(IMediator mediator, IStateQueries stateQueries)
    {
        _mediator = mediator;
        _stateQueries = stateQueries;
    }

    [HttpGet("{all}")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var countries = await _stateQueries.GetAll(cancellationToken);

        return Ok(countries);
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById(long iD, CancellationToken cancellationToken)
    {
        var state = await _stateQueries.GetById(iD, cancellationToken);
        if (state == null)
            return BadRequest("Estado não encontrado.");

        return Ok(state);
    }

}
