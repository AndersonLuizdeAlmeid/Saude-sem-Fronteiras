using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Exams.Commands;
using SaudeSemFronteiras.Application.Exams.Domain;
using SaudeSemFronteiras.Application.Exams.Queries;
using SaudeSemFronteiras.Application.Exams.Repository;

namespace SaudeSemFronteiras.Application.Exams.Handlers;
public class ExamHandler : IRequestHandler<CreateExamCommand, Result>,
                           IRequestHandler<ChangeExamCommand, Result>
{
    private readonly IExamRepository _examRepository;
    private readonly IExamQueries _examQueries;

    public ExamHandler(IExamRepository examRepository, IExamQueries examQueries)
    {
        _examRepository = examRepository;
        _examQueries = examQueries;
    }

    public async Task<Result> Handle(CreateExamCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var exam = Exam.Create(request.Description, request.Justification, request.LocalExam, request.Results, request.Comments, request.DocumentId);

        await _examRepository.Insert(exam, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Handle(ChangeExamCommand request, CancellationToken cancellationToken)
    {
        var exam = await _examQueries.GetById(request.Id, cancellationToken);
        if (exam == null)
            return Result.Failure("Exame não encontrado");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        exam.Update(request.Description, request.Justification, DateTime.Now, request.LocalExam, request.Results, request.Comments, request.DocumentId);

        await _examRepository.Update(exam, cancellationToken);

        return Result.Success();
    }
}
