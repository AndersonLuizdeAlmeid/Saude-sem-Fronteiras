using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Scheduled.Commands;
using SaudeSemFronteiras.Application.Scheduled.Domain;
using SaudeSemFronteiras.Application.Scheduled.Queries;
using SaudeSemFronteiras.Application.Scheduled.Repository;
using System.Diagnostics;

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

        var schedule = Schedule.Create(request.Price, request.ScheduledDate, request.AppointmentId);

        await _scheduleRepository.Insert(schedule, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Handle(ChangeScheduleCommand request, CancellationToken cancellationToken)
    {
        var scheduleDto = await _scheduleQueries.GetById(request.Id, cancellationToken);
        if (scheduleDto == null)
            return Result.Failure("Consulta agendada não encontrada");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        Schedule schedule = new Schedule(scheduleDto.Id,
                                         scheduleDto.Price,
                                         scheduleDto.ScheduledDate,
                                         scheduleDto.Status,
                                         scheduleDto.AppointmentId);

        if (request.Status != 3)
            request.Price = scheduleDto.Price;

        schedule.Update(request.Price, request.Status);

        await _scheduleRepository.Update(schedule, cancellationToken);

        return Result.Success();
    }
}
