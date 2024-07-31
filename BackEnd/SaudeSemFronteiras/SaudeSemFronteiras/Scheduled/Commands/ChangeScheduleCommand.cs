using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Scheduled.Commands;
public class ChangeScheduleCommand : IRequest<Result>
{
    public long Id { get; set; }
    public string Value { get; set; } = string.Empty;
    public DateTime ScheduledDate { get; set; }
    public bool IsActive { get; set; }
    public long AppointmentId { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta agendada não pode ser nulo.");
        if (Value.IsNullOrEmpty())
            return Result.Failure("Valor da consulta não pode ser nulo.");
        if (ScheduledDate.ToString().IsNullOrEmpty())
            return Result.Failure("Data da consulta não pode ser nulo.");
        if (IsActive.ToString().IsNullOrEmpty())
            return Result.Failure("É necessário estar ativa ou inativa a consulta");
        if (AppointmentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta não pode ser nulo.");

        return Result.Success();
    }
}
