﻿using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Exams.Commands;
public class CreateExamCommand : IRequest<Result>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string LocalExam { get; set; } = string.Empty;
    public string Results { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;

    public Result Validation()
    {
        if (Title.IsNullOrEmpty())
            return Result.Failure("Título do exame não pode ser nulo.");
        if (Description.IsNullOrEmpty())
            return Result.Failure("Descrição do exame não pode ser nulo.");
        if (LocalExam.IsNullOrEmpty())
            return Result.Failure("Local do exame não pode ser nulo.");

        return Result.Success();
    }
}
