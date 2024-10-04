using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Prescriptions.Commands;
public class ChangePrescriptionCommand : IRequest<Result>
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public long DocumentId { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código da receita não pode ser nulo.");
        if (Description.IsNullOrEmpty())
            return Result.Failure("Descrição do receita não pode ser nulo.");
        if (DocumentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código do documento não pode ser nulo.");

        return Result.Success();
    }
}
