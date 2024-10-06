using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Patients.Commands;
public class ChangePatientCommand : IRequest<Result>
{
    public long Id { get; set; }
    public string BloodType { get; set; } = string.Empty;
    public string Allergies { get; set; } = string.Empty;
    public string MedicalCondition { get; set; } = string.Empty;
    public string PreviousSurgeries { get; set; } = string.Empty;
    public string Medicines { get; set; } = string.Empty;
    public string EmergencyNumber { get; set; } = string.Empty;
    public long UserId { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código do paciente não pode ser nulo");
        if (BloodType.IsNullOrEmpty())
            return Result.Failure("Tipo Sanguíneo não pode ser nulo");
        if (MedicalCondition.IsNullOrEmpty())
            return Result.Failure("Condição médica não pode ser nula");
        if (EmergencyNumber.IsNullOrEmpty())
            return Result.Failure("Número de emergencia não pode ser nulo");
        if (UserId.ToString().IsNullOrEmpty())
            return Result.Failure("Código do usuário não pode ser nulo");

        return Result.Success();
    }
}
