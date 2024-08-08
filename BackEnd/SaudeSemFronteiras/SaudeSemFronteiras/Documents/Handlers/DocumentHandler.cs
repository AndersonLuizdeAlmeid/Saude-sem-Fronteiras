using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Documents.Commands;
using SaudeSemFronteiras.Application.Documents.Domain;
using SaudeSemFronteiras.Application.Documents.Queries;
using SaudeSemFronteiras.Application.Documents.Repository;

namespace SaudeSemFronteiras.Application.Documents.Handlers;
public class DocumentHandler : IRequestHandler<CreateDocumentCommand, Result>,
                               IRequestHandler<ChangeDocumentCommand, Result>
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IDocumentQueries _documentQueries;

    public DocumentHandler(IDocumentRepository documentRepository, IDocumentQueries documentQueries)
    {
        _documentRepository = documentRepository;
        _documentQueries = documentQueries;
    }

    public async Task<Result> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var document = Document.Create(request.Description, request.TypeDocument, request.DateDocument, request.DigitallySigned, request.AppointmentId);

        await _documentRepository.Insert(document, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Handle(ChangeDocumentCommand request, CancellationToken cancellationToken)
    {
        var document = await _documentQueries.GetById(request.Id, cancellationToken);
        if (document == null)
            return Result.Failure("Documento não encontrado");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        document.Update(request.Description, request.TypeDocument, request.DateDocument, request.DigitallySigned, request.AppointmentId);

        await _documentRepository.Update(document, cancellationToken);

        return Result.Success();
    }
}
