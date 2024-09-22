using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Appointments.Commands;
public class DeleteAppointmentCommand : IRequest<Result>
{
    public long Id { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta não pode ser nulo.");

        return Result.Success();
    }
}
