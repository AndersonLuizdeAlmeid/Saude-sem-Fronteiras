using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Medicines.Commands;
public class CreateMedicineCommand : IRequest<Result>
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
    public string Observation { get; set; } = string.Empty;
    public long PrescriptionId { get; set; }

    public Result Validation()
    {
        if (Description.IsNullOrEmpty())
            return Result.Failure("Descrição do receita não pode ser nulo.");
        if (Quantity.IsNullOrEmpty())
            return Result.Failure("Quantidade não pode ser nulo.");
        if (Dosage.IsNullOrEmpty())
            return Result.Failure("Dosagem não pode ser nulo.");
        if (Observation.IsNullOrEmpty())
            return Result.Failure("Observação não pode ser nulo.");

        return Result.Success();
    }
}
