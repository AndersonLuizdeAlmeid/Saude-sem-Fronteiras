using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Cities.Queries;
using SaudeSemFronteiras.Application.Countries.Queries;

namespace SaudeSemFronteiras.WebApi.Controllers;
[ApiController]
[Route("[controller]")]

public class CityController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICityQueries _cityQueries;

    public CityController(IMediator mediator, ICityQueries cityQueries)
    {
        _mediator = mediator;
        _cityQueries = cityQueries;
    }

    [HttpGet("{all}")]

    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var cities = await _cityQueries.GetAll(cancellationToken);

        return Ok(cities);
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetCityByAddressId(long iD, CancellationToken cancellationToken)
    {
        var city = await _cityQueries.GetById(iD, cancellationToken);
        if (city == null)
            return BadRequest("Cidade não encontrada.");

        return Ok(city);
    }
}
