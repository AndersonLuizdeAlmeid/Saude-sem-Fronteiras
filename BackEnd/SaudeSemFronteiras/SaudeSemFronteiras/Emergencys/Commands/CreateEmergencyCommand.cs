using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Emergencys.Commands;
public class CreateEmergencyCommand : IRequest<Result>
{
    public string Value { get; set; } = string.Empty;
    public DateTime WaitTime { get; set; }
    public bool IsActive { get; set; }
    public long AppointmentId { get; set; }

    public Result Validation()
    {
        if (Value.IsNullOrEmpty())
            return Result.Failure("Valor da consulta emergencial não pode ser nulo");
        if (IsActive.ToString().IsNullOrEmpty())
            return Result.Failure("É necessário estar ativa ou inativa a consulta");
        if (AppointmentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta não pode ser nulo");

        return Result.Success();
    }
}
