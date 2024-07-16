using CSharpFunctionalExtensions;
using MediatR;

namespace SaudeSemFronteiras.Application.Login.Commands;
public class ChangeCredentialsCommand : IRequest<Result>
{
    public long Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Result Validation()
    {
        if (string.IsNullOrEmpty(Email))
            return Result.Failure("Email não pode ser nulo");
        if (string.IsNullOrEmpty(Password))
            return Result.Failure("Password não pode ser nulo");

        return Result.Success();
    }
}
