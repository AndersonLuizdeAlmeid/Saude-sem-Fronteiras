using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Emergencys.Commands;
using SaudeSemFronteiras.Application.Emergencys.Domain;
using SaudeSemFronteiras.Application.Emergencys.Repository;

namespace SaudeSemFronteiras.Application.Emergencys.Handlers;
public class EmergencyHandler : IRequestHandler<CreateEmergencyCommand, Result>,
                                IRequestHandler<ChangeEmergencyCommand, Result>
{
    public readonly IEmergencyRepository _emergencyRepository;

    public EmergencyHandler(IEmergencyRepository emergencyRepository)
    {
        _emergencyRepository = emergencyRepository;
    }
    public async Task<Result> Handle(CreateEmergencyCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var emergency = Emergency.Create(request.Value, request.WaitTime, request.AppointmentId);

        await _emergencyRepository.Insert(emergency, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Handle(ChangeEmergencyCommand request, CancellationToken cancellationToken)
    {
        var Emergency = await _emergencyRepository.GetById(request.Id, cancellationToken);
        if (Emergency == null)
            return Result.Failure("Especialidade não encontrada");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        Emergency.Update(request.Value, request.WaitTime, request.IsActive, request.AppointmentId);

        await _emergencyRepository.Update(Emergency, cancellationToken);

        return Result.Success();
    }
}
