using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Prescriptions.Commands;
using SaudeSemFronteiras.Application.Prescriptions.Domain;
using SaudeSemFronteiras.Application.Prescriptions.Queries;
using SaudeSemFronteiras.Application.Prescriptions.Repository;

namespace SaudeSemFronteiras.Application.Prescriptions.Handlers;
public class PrescritpionHandler : IRequestHandler<CreatePrescriptionCommand, Result>,
                                   IRequestHandler<ChangePrescriptionCommand, Result>
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IPrescriptionQueries _prescriptionQueries;

    public PrescritpionHandler(IPrescriptionRepository prescriptionRepository, IPrescriptionQueries prescriptionQueries)
    {
        _prescriptionRepository = prescriptionRepository;
        _prescriptionQueries = prescriptionQueries;
    }

    public async Task<Result> Handle(CreatePrescriptionCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var prescription = Prescription.Create(request.Description, request.DocumentId);

        await _prescriptionRepository.Insert(prescription, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(ChangePrescriptionCommand request, CancellationToken cancellationToken)
    {
        //TODO Ver possibilidade de bloquear quando tiver consultas abertas.
        var prescription = await _prescriptionQueries.GetByID(request.Id, cancellationToken);
        if (prescription == null)
            return Result.Failure("Receita não encontrado");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        prescription.Update(request.Description, request.DocumentId);

        await _prescriptionRepository.Update(prescription, cancellationToken);

        return Result.Success();
    }
}
