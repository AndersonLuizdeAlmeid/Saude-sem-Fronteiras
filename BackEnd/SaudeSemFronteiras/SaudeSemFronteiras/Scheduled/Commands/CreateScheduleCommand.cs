using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Scheduled.Commands;
public class CreateScheduleCommand : IRequest<Result>
{
    public string Value { get; set; } = string.Empty;
    public DateTime ScheduledDate { get; set; }
    public bool IsActive { get; set; }
    public long AppointmentId { get; set; }

    public Result Validation()
    {
        if (Value.IsNullOrEmpty())
            return Result.Failure("Valor da consulta não pode ser nulo.");
        if (ScheduledDate.ToString().IsNullOrEmpty())
            return Result.Failure("Data da consulta não pode ser nulo.");
        if (IsActive.ToString().IsNullOrEmpty())
            return Result.Failure("Valor da atividade não pode ser nulo.");
        if (AppointmentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta não pode ser nulo.");

        return Result.Success();
    }
}
