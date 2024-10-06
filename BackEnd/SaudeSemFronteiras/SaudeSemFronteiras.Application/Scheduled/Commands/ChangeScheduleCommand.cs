using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace SaudeSemFronteiras.Application.Scheduled.Commands;
public class ChangeScheduleCommand : IRequest<Result>
{
    public long Id { get; set; }
    public decimal Price { get; set; }
    public short Status { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta agendada não pode ser nulo.");
        if (Price.ToString().IsNullOrEmpty())
            return Result.Failure("Preço da consulta não pode ser nulo.");
        if (Status.ToString().IsNullOrEmpty())
            return Result.Failure("Status da consulta não pode ser nulo");

        return Result.Success();
    }
}
