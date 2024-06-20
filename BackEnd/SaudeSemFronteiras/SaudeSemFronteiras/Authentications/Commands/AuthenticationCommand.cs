using CSharpFunctionalExtensions;
using MediatR;

namespace SaudeSemFronteiras.Application.Authentications.Commands;
public class AuthenticationCommand : IRequest<Result<string>>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
