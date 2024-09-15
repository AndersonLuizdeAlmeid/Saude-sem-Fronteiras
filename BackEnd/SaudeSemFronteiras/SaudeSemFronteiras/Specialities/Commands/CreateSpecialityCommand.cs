using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SaudeSemFronteiras.Application.Doctors.Domain;

namespace SaudeSemFronteiras.Application.Specialities.Commands;
public class CreateSpecialityCommand : IRequest<Result>
{
    public string Description { get; set; } = string.Empty;
    public long DoctorId { get; set; }

    public Result Validation()
    {
        if (Description.ToString().IsNullOrEmpty())
            return Result.Failure("Descrição da especialidade não pode ser nula");
        if (DoctorId.ToString().IsNullOrEmpty())
            return Result.Failure("Código do médico não pode ser nulo");

        return Result.Success();
    }
}

