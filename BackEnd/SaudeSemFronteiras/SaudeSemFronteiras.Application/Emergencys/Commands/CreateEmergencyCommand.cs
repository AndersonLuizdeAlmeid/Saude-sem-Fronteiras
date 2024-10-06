using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Emergencys.Commands;
public class CreateEmergencyCommand : IRequest<Result>
{
    public decimal Price { get; set; }
    public long AppointmentId { get; set; }

    public Result Validation()
    {
        if (Price.ToString().IsNullOrEmpty())
            return Result.Failure("Valor da consulta emergencial não pode ser nulo");
        if (AppointmentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta não pode ser nulo");

        return Result.Success();
    }
}
