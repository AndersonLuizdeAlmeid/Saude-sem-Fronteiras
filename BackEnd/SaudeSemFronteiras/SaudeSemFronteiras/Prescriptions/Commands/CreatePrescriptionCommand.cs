using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Prescriptions.Commands;
public class CreatePrescriptionCommand : IRequest<Result>
{
    public string Description { get; set; } = string.Empty;
    public long DocumentId { get; set; }

    public Result Validation()
    {
        if (Description.IsNullOrEmpty())
            return Result.Failure("Descrição do receita não pode ser nulo.");
        if (DocumentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código do documento não pode ser nulo.");

        return Result.Success();
    }
}
