using CSharpFunctionalExtensions;
using MediatR;

namespace SaudeSemFronteiras.Application.Login.Commands;
public class ChangeCredentialsCommand : IRequest<Result>
{
    public long Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
