using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Emergencys.Commands;
using SaudeSemFronteiras.Application.Emergencys.Domain;
using SaudeSemFronteiras.Application.Emergencys.Queries;
using SaudeSemFronteiras.Application.Emergencys.Repository;

namespace SaudeSemFronteiras.Application.Emergencys.Handlers;
public class EmergencyHandler : IRequestHandler<CreateEmergencyCommand, Result>,
                                IRequestHandler<ChangeEmergencyCommand, Result>
{
    public readonly IEmergencyRepository _emergencyRepository;
    public readonly IEmergencyQueries _emergencyQueries;

    public EmergencyHandler(IEmergencyRepository emergencyRepository, IEmergencyQueries emergencyQueries)
    {
        _emergencyRepository = emergencyRepository;
        _emergencyQueries = emergencyQueries;
    }

    public async Task<Result> Handle(CreateEmergencyCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var dateNow = DateTime.Now.ToString();

        var emergency = Emergency.Create(request.Price, dateNow, request.AppointmentId);

        await _emergencyRepository.Insert(emergency, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Handle(ChangeEmergencyCommand request, CancellationToken cancellationToken)
    {
        var emergencyDto = await _emergencyQueries.GetById(request.Id, cancellationToken);
        if (emergencyDto == null)
            return Result.Failure("Consulta emergencial não encontrada");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        Emergency emergency = new Emergency(emergencyDto.Id,
                                            emergencyDto.Price,
                                            emergencyDto.WaitTime,
                                            emergencyDto.Status,
                                            emergencyDto.AppointmentId);

        if (request.Status != 3)
            request.Price = emergency.Price;

        emergency.Update(request.Price, request.WaitTime, request.Status, emergencyDto.AppointmentId);

        await _emergencyRepository.Update(emergency, cancellationToken);

        return Result.Success();
    }
}
