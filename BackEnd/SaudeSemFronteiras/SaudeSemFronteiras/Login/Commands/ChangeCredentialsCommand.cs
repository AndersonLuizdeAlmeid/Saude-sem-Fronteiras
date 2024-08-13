using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Login.Commands;
public class ChangeCredentialsCommand : IRequest<Result>
{
    public long Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public long UserId { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código do login não pode ser nulo");
        if (string.IsNullOrEmpty(Email))
            return Result.Failure("Email não pode ser nulo");
        if (string.IsNullOrEmpty(Password))
            return Result.Failure("Password não pode ser nulo");
        if (UserId.ToString().IsNullOrEmpty())
            return Result.Failure("Código do usuário não pode ser nulo");

        return Result.Success();
    }
}
