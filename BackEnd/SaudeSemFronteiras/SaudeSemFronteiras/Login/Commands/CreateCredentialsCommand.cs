using CSharpFunctionalExtensions;
using MediatR;
using System.Xml.Linq;

namespace SaudeSemFronteiras.Application.Login.Commands;
public class CreateCredentialsCommand : IRequest<Result>
{
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
