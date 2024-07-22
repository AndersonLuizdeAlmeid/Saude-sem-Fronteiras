using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Doctors.Commands;
public class CreateDoctorCommand : IRequest<Result>
{
    public string RegistryNumber { get; set; } = string.Empty;
    public string AvaibalityHours { get; set; } = string.Empty;
    public decimal ConsultationPrince { get; set; }
    public long IdUser { get; set; }
    public long IdAppointment { get; set; }

    public Result Validation()
    {
        if (string.IsNullOrEmpty(RegistryNumber))
            return Result.Failure("Número do registro não pode ser nulo");
        if (string.IsNullOrEmpty(AvaibalityHours))
            return Result.Failure("Horários de disponibilidade não pode ser nulo");
        if (ConsultationPrince.ToString().IsNullOrEmpty())
            return Result.Failure("Preço de consulta não pode ser nulo");
        if (IdUser.ToString().IsNullOrEmpty())
            return Result.Failure("Usuário não pode ser nulo");
        if (IdAppointment.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta não pode ser nulo");

        return Result.Success();
    }
}
