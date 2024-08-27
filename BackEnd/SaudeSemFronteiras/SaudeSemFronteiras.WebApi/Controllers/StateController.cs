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

}
