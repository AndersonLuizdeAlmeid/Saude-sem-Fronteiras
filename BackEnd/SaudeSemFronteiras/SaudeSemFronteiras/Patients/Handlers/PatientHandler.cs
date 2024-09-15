using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Patients.Commands;
using SaudeSemFronteiras.Application.Patients.Domain;
using SaudeSemFronteiras.Application.Patients.Queries;
using SaudeSemFronteiras.Application.Patients.Repository;

namespace SaudeSemFronteiras.Application.Patients.Handlers;
public class PatientHandler : IRequestHandler<CreatePatientCommand, Result>,
                              IRequestHandler<ChangePatientCommand, Result>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IPatientQueries _patientQueries;

    public PatientHandler(IPatientRepository patientRepository, IPatientQueries patientQueries)
    {
        _patientRepository = patientRepository;
        _patientQueries = patientQueries;
    }

    public async Task<Result> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var patient = Patient.Create(request.BloodType, request.Allergies, request.MedicalCondition, request.PreviousSurgeries, request.Medicines, request.EmergencyNumber, request.UserId);

        await _patientRepository.Insert(patient, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(ChangePatientCommand request, CancellationToken cancellationToken)
    {
        var patientDto = await _patientQueries.GetByUserId(request.UserId, cancellationToken);
        if (patientDto == null)
            return Result.Failure("Paciente não encontrado");

        var validationResult = request.Validation();
        if (validationResult.IsFailure)
            return validationResult;

        Patient patient = new Patient(patientDto.Id, request.BloodType, request.Allergies, request.MedicalCondition, request.PreviousSurgeries, request.Medicines, request.EmergencyNumber, request.UserId);

        patient.Update(request.BloodType, request.Allergies, request.MedicalCondition, request.PreviousSurgeries, request.Medicines, request.EmergencyNumber, request.UserId);

        await _patientRepository.Update(patient, cancellationToken);

        return Result.Success();
    }
}
