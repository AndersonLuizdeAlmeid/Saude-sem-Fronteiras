using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Appointments.Commands;
public class ChangeAppointmentCommand : IRequest<Result>
{
    public long Id { get; set; }
    public DateTime Time { get; set; }
    public decimal Duration { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta não pode ser nulo");
        if (Time.ToString().IsNullOrEmpty())
            return Result.Failure("Horário não pode ser nulo");

        return Result.Success();
    }
}
