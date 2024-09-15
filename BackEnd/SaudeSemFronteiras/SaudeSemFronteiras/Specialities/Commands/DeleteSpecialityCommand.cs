using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Specialities.Commands;
public class DeleteSpecialityCommand : IRequest<Result>
{
    public long Id { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código da especialidade não pode ser nulo.");

        return Result.Success();
    }
}
