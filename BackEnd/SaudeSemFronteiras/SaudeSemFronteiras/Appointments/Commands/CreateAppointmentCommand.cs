using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Appointments.Commands;
public class CreateAppointmentCommand : IRequest<Result>
{
    public DateTime Date { get; set; }
    public decimal Duration { get; set; }
    public long? DoctorId { get; set; }
    public long PatientId { get; set; }

    public Result Validation()
    {
        if (Date.ToString().IsNullOrEmpty())
            return Result.Failure("Horário não pode ser nulo");
        if (PatientId.ToString().IsNullOrEmpty())
            return Result.Failure("Código do paciente não pode ser nulo");
        if(DoctorId == 0) 
            DoctorId = null;

        return Result.Success();
    }
}
