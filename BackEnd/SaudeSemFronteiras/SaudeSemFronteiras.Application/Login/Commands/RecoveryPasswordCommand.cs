using CSharpFunctionalExtensions;
using MediatR;

namespace SaudeSemFronteiras.Application.Login.Commands;
public class RecoveryPasswordCommand : IRequest<Result>
{
    public string Email { get; set; } = string.Empty;

    public Result Validation()
    {
        if (string.IsNullOrEmpty(Email))
            return Result.Failure("Email não pode ser nulo");

        return Result.Success();
    }
}
