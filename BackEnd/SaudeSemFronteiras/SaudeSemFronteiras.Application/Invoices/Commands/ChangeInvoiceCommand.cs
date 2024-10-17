using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Invoices.Commands;
public class ChangeInvoiceCommand : IRequest<Result>
{
    public long Id { get; set; }
    public short Status { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código do fatura não pode ser nulo.");
        if (Status.ToString().IsNullOrEmpty())
            return Result.Failure("Status da fatura não pode ser nulo.");

        return Result.Success();
    }
}
