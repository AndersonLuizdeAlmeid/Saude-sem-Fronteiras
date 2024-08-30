using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Phones.Commands;
public class DeletePhoneCommand : IRequest<Result>
{
    public long Id { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código do telefone não pode ser nulo.");

        return Result.Success();
    }
}
