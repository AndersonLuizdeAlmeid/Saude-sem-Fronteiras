using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Prescriptions.Commands;
public class CreatePrescriptionCommand : IRequest<Result>
{
    public DateTime IssuanceDate { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public DateTime FinalDate { get; set; }
    public string Observations { get; set; } = string.Empty;
    public DateTime PrescriptionValidate { get; set; }
    public long DocumentId { get; set; }

    public Result Validation()
    {
        if (IssuanceDate.ToString().IsNullOrEmpty())
            return Result.Failure("Data de emissão receita não pode ser nulo.");
        if (Title.IsNullOrEmpty())
            return Result.Failure("Título do receita não pode ser nulo.");
        if (Description.IsNullOrEmpty())
            return Result.Failure("Descrição do receita não pode ser nulo.");
        if (Instructions.IsNullOrEmpty())
            return Result.Failure("Instruções do receita não pode ser nulo.");
        if (PrescriptionValidate.ToString().IsNullOrEmpty())
            return Result.Failure("Data de válidade do receita não pode ser nulo.");
        if (DocumentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código do documento não pode ser nulo.");

        return Result.Success();
    }
}
