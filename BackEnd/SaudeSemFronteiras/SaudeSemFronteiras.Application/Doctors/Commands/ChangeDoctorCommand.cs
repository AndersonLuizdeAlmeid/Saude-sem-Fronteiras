﻿using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Doctors.Commands;
public class ChangeDoctorCommand : IRequest<Result>
{
    public long Id { get;  set; }
    public string RegistryNumber { get;  set; } = string.Empty;
    public string InitialHour { get; set; } = string.Empty;
    public string FinalHour { get; set; } = string.Empty;
    public decimal ConsultationPrice { get;  set; }
    public string Days { get; set; } = string.Empty;
    public long UserId { get;  set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código do médico não pode ser nulo");
        if (RegistryNumber.IsNullOrEmpty())
            return Result.Failure("Número do registro não pode ser nulo");
        if (string.IsNullOrEmpty(InitialHour))
            return Result.Failure("Hora final de atendimento não pode ser nulo");
        if (string.IsNullOrEmpty(FinalHour))
            return Result.Failure("Hora final de atendimento não pode ser nulo");
        if (ConsultationPrice.ToString().IsNullOrEmpty())
            return Result.Failure("Preço de consulta não pode ser nulo");
        if (UserId.ToString().IsNullOrEmpty())
            return Result.Failure("Usuário não pode ser nulo");

        return Result.Success();
    }
}