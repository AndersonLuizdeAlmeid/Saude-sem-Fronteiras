using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Emergencys.Commands;
public class ChangeEmergencyCommand : IRequest<Result>
{
    public long Id { get; set; }
    public decimal Price { get; set; }
    public string WaitTime { get; set; } = string.Empty;
    public short Status { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta emergencial não pode ser nulo");
        if (Price.ToString().IsNullOrEmpty())
            return Result.Failure("Valor da consulta emergencial não pode ser nulo");
        if (Status.ToString().IsNullOrEmpty())
            return Result.Failure("Status da consulta não pode ser nulo");

        return Result.Success();
    }
}
