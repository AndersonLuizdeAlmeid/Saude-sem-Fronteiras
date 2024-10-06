using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Screenings.Commands;
public class CreateScreeningCommand : IRequest<Result>
{
    public string Symptons { get; set; } = string.Empty;
    public string DateSymptons { get; set; } = string.Empty;
    public string ContinuosMedicine { get; set; } = string.Empty;
    public string Allergies { get; set; } = string.Empty;
    public string Observations { get; set; } = string.Empty;
    public long EmergencyId { get; set; }

    public Result Validation()
    {
        if (Symptons.IsNullOrEmpty())
            return Result.Failure("Sintomas não pode ser nulo.");
        if (DateSymptons.IsNullOrEmpty())
            return Result.Failure("Data do sintoma não pode ser nulo.");
        if (EmergencyId.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta emergencial não pode ser nulo.");

        return Result.Success();
    }
}
