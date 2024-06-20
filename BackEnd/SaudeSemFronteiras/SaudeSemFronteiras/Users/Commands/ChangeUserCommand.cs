using CSharpFunctionalExtensions;
using MediatR;

namespace SaudeSemFronteiras.Application.Users.Commands;
public class ChangeUserCommand : IRequest<Result>
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string MotherName { get; set; } = string.Empty;
    public DateTime DateBirth { get; set; }
    public string Language { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
