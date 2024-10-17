using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

public class DeleteInvoiceCommand : IRequest<Result>
{
    public long Id { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código da fatura não pode ser nulo.");

        return Result.Success();
    }
}