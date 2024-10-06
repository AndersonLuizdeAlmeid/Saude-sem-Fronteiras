using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Addresses.Commands;
using SaudeSemFronteiras.Application.Addresses.Queries;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IAddressQueries _addressQueries;

    public AddressController(IMediator mediator, IAddressQueries addressQueries)
    {
        _mediator = mediator;
        _addressQueries = addressQueries;
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetAddressByUserCode(long iD, CancellationToken cancellationToken)
    {
        var address = await _addressQueries.GetByUserId(iD, cancellationToken);
        if(address == null)
            return BadRequest("Endereço não encontrado.");

        return Ok(address);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ChangeAddress([FromBody] ChangeAddressCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
