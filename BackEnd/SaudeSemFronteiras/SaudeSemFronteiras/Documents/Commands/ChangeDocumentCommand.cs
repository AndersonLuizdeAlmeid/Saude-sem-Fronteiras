﻿using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Documents.Commands;
public class ChangeDocumentCommand : IRequest<Result>
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public short TypeDocument { get; set; }
    public DateTime DateDocument { get; set; }
    //:TODO VERIFICAR COMO CRIAR ASSINATURA DIGITAL
    public short DigitallySigned { get; set; }
    public long AppointmentId { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código do documento não pode ser nulo.");
        if (Description.IsNullOrEmpty())
            return Result.Failure("Descrição do documento não pode ser nulo.");
        if (TypeDocument.ToString().IsNullOrEmpty())
            return Result.Failure("Tipo de documento não pode ser nulo.");
        if (DateDocument.ToString().IsNullOrEmpty())
            return Result.Failure("Data do documento não pode ser nulo.");
        if (AppointmentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta não pode ser nulo.");

        return Result.Success();
    }
}
