using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Scheduled.Commands;
public class CreateScheduleCommand : IRequest<Result>
{
    public decimal Price { get; set; }
    public DateTime ScheduledDate { get; set; }
    public long AppointmentId { get; set; }

    public Result Validation()
    {
        if (Price.ToString().IsNullOrEmpty())
            return Result.Failure("Preço da consulta não pode ser nulo.");
        if (ScheduledDate.ToString().IsNullOrEmpty())
            return Result.Failure("Data da consulta não pode ser nulo.");
        if (AppointmentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta não pode ser nulo.");

        return Result.Success();
    }
}
