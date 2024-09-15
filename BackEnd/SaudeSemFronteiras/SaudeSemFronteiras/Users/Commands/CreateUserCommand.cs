using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SaudeSemFronteiras.Application.Addresses.Domain;

namespace SaudeSemFronteiras.Application.Users.Commands;
public class CreateUserCommand : IRequest<Result>
{
    public string Name { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string MotherName { get; set; } = string.Empty;
    public DateTime DateBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public long CredentialsId { get; set; }

    public Result Validation()
    {
        if (string.IsNullOrEmpty(Name))
            return Result.Failure("Nome não pode ser nulo");
        if (string.IsNullOrEmpty(CPF))
            return Result.Failure("CPF não pode ser nulo");
        if (string.IsNullOrEmpty(MotherName))
            return Result.Failure("Nome da mãe não pode ser nulo");
        if (DateBirth.ToString().IsNullOrEmpty())
            return Result.Failure("Data de Aniversário não pode nulo");
        if (string.IsNullOrEmpty(Gender))
            return Result.Failure("Genêro não pode ser nulo");
        if (string.IsNullOrEmpty(Language))
            return Result.Failure("Linguagem não pode ser nulo");
        if (CredentialsId.ToString().IsNullOrEmpty())
            return Result.Failure("Código das credenciais não pode ser nulo");

        return Result.Success();
    }
}
