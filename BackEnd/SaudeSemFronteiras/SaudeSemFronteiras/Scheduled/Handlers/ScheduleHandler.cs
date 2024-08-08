using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Scheduled.Commands;
using SaudeSemFronteiras.Application.Scheduled.Domain;
using SaudeSemFronteiras.Application.Scheduled.Queries;
using SaudeSemFronteiras.Application.Scheduled.Repository;

namespace SaudeSemFronteiras.Application.Scheduled.Handlers;
public class ScheduleHandler : IRequestHandler<CreateScheduleCommand, Result>,
                               IRequestHandler<ChangeScheduleCommand, Result>
{
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IScheduleQueries _scheduleQueries;

    public ScheduleHandler(IScheduleRepository scheduleRepository, IScheduleQueries scheduleQueries)
    {
        _scheduleRepository = scheduleRepository;
        _scheduleQueries = scheduleQueries;
    }

    public async Task<Result> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var schedule = Schedule.Create(request.Value, request.ScheduledDate, request.AppointmentId);

        await _scheduleRepository.Insert(schedule, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Handle(ChangeScheduleCommand request, CancellationToken cancellationToken)
    {
        var schedule = await _scheduleQueries.GetById(request.Id, cancellationToken);
        if (schedule == null)
            return Result.Failure("Consulta agendada não encontrada");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        schedule.Update(request.Value, request.ScheduledDate, request.IsActive, request.AppointmentId);

        await _scheduleRepository.Update(schedule, cancellationToken);

        return Result.Success();
    }
}
