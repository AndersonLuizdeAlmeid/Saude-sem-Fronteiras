using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Medicines.Commands;
using SaudeSemFronteiras.Application.Medicines.Queries;
using SaudeSemFronteiras.Application.Medicines.Repositories;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicineController : ControllerBase
{

    private readonly IMediator _mediator;
    private readonly IMedicineQueries _medicineQueries;

    public MedicineController(IMediator mediator, IMedicineQueries medicineQueries)
    {
        _mediator = mediator;
        _medicineQueries = medicineQueries;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMedicine([FromBody] CreateMedicineCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMedicine(long id, CancellationToken cancellationToken)
    {
        var command = new DeleteMedicineCommand { Id = id };
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
