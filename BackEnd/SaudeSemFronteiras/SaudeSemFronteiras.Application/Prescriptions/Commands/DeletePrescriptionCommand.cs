using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Prescriptions.Commands;
public class DeletePrescriptionCommand : IRequest<Result>
{
    public long Id { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código da receita não pode ser nulo.");

        return Result.Success();
    }
}