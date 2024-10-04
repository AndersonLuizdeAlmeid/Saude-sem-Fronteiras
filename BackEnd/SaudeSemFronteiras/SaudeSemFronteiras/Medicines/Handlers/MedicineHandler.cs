using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Medicines.Commands;
using SaudeSemFronteiras.Application.Medicines.Domain;
using SaudeSemFronteiras.Application.Medicines.Queries;
using SaudeSemFronteiras.Application.Medicines.Repositories;

namespace SaudeSemFronteiras.Application.Medicines.Handlers;

public class MedicineHandler : IRequestHandler<CreateMedicineCommand, Result>,
                               IRequestHandler<DeleteMedicineCommand, Result>
{
    private readonly IMedicineRepository _MedicineRepository;
    private readonly IMedicineQueries _MedicineQueries;

    public MedicineHandler(IMedicineRepository MedicineRepository, IMedicineQueries MedicineQueries)
    {
        _MedicineRepository = MedicineRepository;
        _MedicineQueries = MedicineQueries;
    }

    public async Task<Result> Handle(CreateMedicineCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var medicine = Medicine.Create(request.Description, request.Quantity, request.Dosage, request.Observation, request.PrescriptionId);

        await _MedicineRepository.Insert(medicine, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Handle(DeleteMedicineCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        await _MedicineRepository.Delete(request.Id, cancellationToken);

        return Result.Success();
    }
}