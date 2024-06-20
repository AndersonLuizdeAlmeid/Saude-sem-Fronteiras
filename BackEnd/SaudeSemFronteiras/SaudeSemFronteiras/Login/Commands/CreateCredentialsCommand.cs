using CSharpFunctionalExtensions;
using MediatR;

namespace SaudeSemFronteiras.Application.Login.Commands;
public class CreateCredentialsCommand : IRequest<Result>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
