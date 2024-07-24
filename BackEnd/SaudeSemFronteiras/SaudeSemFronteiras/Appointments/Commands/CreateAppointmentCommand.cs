using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Appointments.Commands;
public class CreateAppointmentCommand : IRequest<Result>
{
    public DateTime Time { get; set; }
    public decimal Duration { get; set; }

    public Result Validation()
    {
        if (Time.ToString().IsNullOrEmpty())
            return Result.Failure("Horário não pode ser nulo");

        return Result.Success();
    }
}
