using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Certificates.Commands;
using SaudeSemFronteiras.Application.Certificates.Domain;
using SaudeSemFronteiras.Application.Certificates.Queries;
using SaudeSemFronteiras.Application.Certificates.Repository;
using SaudeSemFronteiras.Application.Documents.Commands;

namespace SaudeSemFronteiras.Application.Certificates.Handlers;
public class CertificateHandler : IRequestHandler<CreateCertificateCommand, Result>,
                                  IRequestHandler<ChangeCertificateCommand, Result>,
                                  IRequestHandler<DeleteCertificateCommand, Result>
{
    private readonly ICertificateRepository _certificateRepository;
    private readonly ICertificateQueries _certificateQueries;

    public CertificateHandler(ICertificateRepository certificateRepository, ICertificateQueries certificateQueries)
    {
        _certificateRepository = certificateRepository;
        _certificateQueries = certificateQueries;
    }

    public async Task<Result> Handle(CreateCertificateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var certificate = Certificate.Create(request.Name, request.Cpf, request.Days, request.Cid, request.DocumentId);

        await _certificateRepository.Insert(certificate, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(ChangeCertificateCommand request, CancellationToken cancellationToken)
    {
        //TODO Ver possibilidade de bloquear quando tiver consultas abertas.
        var certificate = await _certificateQueries.GetByID(request.Id, cancellationToken);
        if (certificate == null)
            return Result.Failure("Atestado não encontrado");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        certificate.Update(request.Name, request.Cpf, request.Days, request.Cid, request.DocumentId);

        await _certificateRepository.Update(certificate, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(DeleteCertificateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        await _certificateRepository.Delete(request.Id, cancellationToken);

        return Result.Success();
    }
}
