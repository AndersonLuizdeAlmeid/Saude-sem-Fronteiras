using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Specialities.Commands;
public class CreateSpecialityCommand : IRequest<Result>
{
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    public Result Validation()
    {
         if (Description.ToString().IsNullOrEmpty())
            return Result.Failure("Descrição da especialidade não pode ser nula");

        return Result.Success();
    }
}

