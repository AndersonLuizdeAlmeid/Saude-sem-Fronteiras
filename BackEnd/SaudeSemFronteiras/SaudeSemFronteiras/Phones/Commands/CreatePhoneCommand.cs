using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Phones.Commands;
public class CreatePhoneCommand : IRequest<Result>
{
    public string Number { get; set; } = string.Empty;
    public long UserId { get; set; }

    public Result Validation()
    {
        if (Number.IsNullOrEmpty())
            return Result.Failure("Número não pode ser nulo.");
        if (UserId.ToString().IsNullOrEmpty())
            return Result.Failure("Código do usuário não pode ser nulo.");

        return Result.Success();
    }
}
