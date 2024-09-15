using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Doctors.Queries;
using SaudeSemFronteiras.Application.Patients.Queries;
using SaudeSemFronteiras.Application.Users.Commands;
using SaudeSemFronteiras.Application.Users.Queries;
using SaudeSemFronteiras.WebApi.Authorizations;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IMediator _mediator, IUserQueries _usersQueries, IPatientQueries _patientQueries, IDoctorQueries _doctorQueries) : ControllerBase
{
    [HttpGet]
    [Authorization]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var users = await _usersQueries.GetAll(cancellationToken);

        return Ok(users);
    }

    [HttpGet]
    public async Task<IActionResult> GetLastCreateId(CancellationToken cancellationToken)
    {
        var id = await _usersQueries.GetLastCreateId(cancellationToken);
        if(id == 0)
            return BadRequest("Não existe Código de usuário criado.");
        return Ok(id);
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetTypeUserById(long iD, CancellationToken cancellationToken)
    {
        var doctor = _doctorQueries.GetByUserId(iD, cancellationToken);
        if (doctor.Result != null)
            return Ok(1);

        var patient = _patientQueries.GetByUserId(iD, cancellationToken);
        if (patient.Result != null)
            return Ok(2);

        return Ok(0);
    }

    [HttpGet("credentialsId/{id}")]
    public async Task<IActionResult> GetUserByCredentialsId(long id, CancellationToken cancellationToken)
    {
        var user = await _usersQueries.GetUserByCredentialsId(id, cancellationToken);

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    //[Authorization]
    public async Task<IActionResult> ChangeUser([FromBody] ChangeUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
