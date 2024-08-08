using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Appointments.Commands;
using SaudeSemFronteiras.Application.Appointments.Domain;
using SaudeSemFronteiras.Application.Appointments.Queries;
using SaudeSemFronteiras.Application.Appointments.Repository;

namespace SaudeSemFronteiras.Application.Appointments.Handlers;
public class AppointmentHandler : IRequestHandler<CreateAppointmentCommand, Result>,
                                  IRequestHandler<ChangeAppointmentCommand, Result>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IAppointmentQueries _appointmentQueries;

    public AppointmentHandler(IAppointmentRepository appointmentRepository, IAppointmentQueries appointmentQueries)
    {
        _appointmentRepository = appointmentRepository;
        _appointmentQueries = appointmentQueries;
    }

    public async Task<Result> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var appointment = Appointment.Create(request.Time, request.Duration);

        await _appointmentRepository.Insert(appointment, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(ChangeAppointmentCommand request, CancellationToken cancellationToken)
    {
        //TODO Ver possibilidade de bloquear quando tiver consultas abertas.
        var appointment = await _appointmentQueries.GetById(request.Id, cancellationToken);
        if (appointment == null)
            return Result.Failure("Consulta não encontrada");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        appointment.Update(request.Time, request.Duration);

        await _appointmentRepository.Update(appointment, cancellationToken);

        return Result.Success();
    }
}
