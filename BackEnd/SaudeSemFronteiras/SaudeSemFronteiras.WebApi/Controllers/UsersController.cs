﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Users.Commands;
using SaudeSemFronteiras.Application.Users.Queries;
using SaudeSemFronteiras.WebApi.Authorizations;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IMediator _mediator, IUserQueries _usersQueries) : ControllerBase
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

        return Ok(id);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result);
    }

    [HttpPut]
    [Authorization]
    public async Task<IActionResult> ChangeUser([FromBody] ChangeUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
