using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Certificates.Commands;
using SaudeSemFronteiras.Application.Certificates.Domain;
using SaudeSemFronteiras.Application.Certificates.Repository;

namespace SaudeSemFronteiras.Application.Certificates.Handlers;
internal class CertificateHandler : IRequestHandler<CreateCertificateCommand, Result>,
                                    IRequestHandler<ChangeCertificateCommand, Result>
{
    private readonly ICertificateRepository _certificateRepository;

    public CertificateHandler(ICertificateRepository certificateRepository)
    {
        _certificateRepository = certificateRepository;
    }

    public async Task<Result> Handle(CreateCertificateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var certificate = Certificate.Create(request.Title, request.Description, request.StartDate, request.FinalDate, request.Observations, request.DocumentId);

        await _certificateRepository.Insert(certificate, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(ChangeCertificateCommand request, CancellationToken cancellationToken)
    {
        //TODO Ver possibilidade de bloquear quando tiver consultas abertas.
        var certificate = await _certificateRepository.GetByID(request.Id, cancellationToken);
        if (certificate == null)
            return Result.Failure("Atestado não encontrado");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        certificate.Update(request.IssuanceDate, request.Title, request.Description, request.StartDate, request.FinalDate, request.Observations, request.DocumentId);

        await _certificateRepository.Update(certificate, cancellationToken);

        return Result.Success();
    }


}
