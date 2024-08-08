﻿using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Addresses.Commands;
public class CreateAddressCommand : IRequest<Result>
{
    public string District { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Complement { get; set; } = string.Empty;
    public long CityId { get; set; }

    public Result Validation()
    {
        if (string.IsNullOrEmpty(District))
            return Result.Failure("Nome do distrito não pode ser nulo");
        if (string.IsNullOrEmpty(Street))
            return Result.Failure("Nome da rua não pode ser nulo");
        if (string.IsNullOrEmpty(Number))
            return Result.Failure("Linguagem não pode ser nulo");
        if (CityId.ToString().IsNullOrEmpty())
            return Result.Failure("Código da cidade não pode ser nulo");
        return Result.Success();
    }
}
