﻿using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Exams.Commands;
using SaudeSemFronteiras.Application.Exams.Domain;
using SaudeSemFronteiras.Application.Exams.Repository;

namespace SaudeSemFronteiras.Application.Exams.Handlers;
public class ExamHandler : IRequestHandler<CreateExamCommand, Result>,
                           IRequestHandler<ChangeExamCommand, Result>
{
    private readonly IExamRepository _examRepository;

    public ExamHandler(IExamRepository examRepository)
    {
        _examRepository = examRepository;
    }

    public async Task<Result> Handle(CreateExamCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var exam = Exam.Create(request.Title, request.Description, DateTime.Now, request.LocalExam, request.Results, request.Comments);

        await _examRepository.Insert(exam, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Handle(ChangeExamCommand request, CancellationToken cancellationToken)
    {
        var exam = await _examRepository.GetById(request.Id, cancellationToken);
        if (exam == null)
            return Result.Failure("Exame não encontrado");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        exam.Update(request.Title, request.Description, DateTime.Now, request.LocalExam, request.Results, request.Comments);

        await _examRepository.Update(exam, cancellationToken);

        return Result.Success();
    }
}
