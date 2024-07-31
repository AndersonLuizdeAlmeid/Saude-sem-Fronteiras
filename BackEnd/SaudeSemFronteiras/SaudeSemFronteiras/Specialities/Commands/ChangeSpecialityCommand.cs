using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Specialities.Commands;
public class ChangeSpecialityCommand : IRequest<Result>
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public long IdDoctor { get; set; }

    public Result Validation ()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código da especialidade não pode ser nulo");
        if (Description.ToString().IsNullOrEmpty())
            return Result.Failure("Descrição da especialidade não pode ser nula");
        if (IsActive.ToString().IsNullOrEmpty())
            return Result.Failure("É necessário estar ativa ou inativa a especialidade");
        if (IdDoctor.ToString().IsNullOrEmpty())
            return Result.Failure("Código do médico não pode ser nulo");

        return Result.Success();
    }
}
