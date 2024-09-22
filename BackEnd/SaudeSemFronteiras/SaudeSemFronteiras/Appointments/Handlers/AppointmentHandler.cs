using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Appointments.Commands;
using SaudeSemFronteiras.Application.Appointments.Domain;
using SaudeSemFronteiras.Application.Appointments.Queries;
using SaudeSemFronteiras.Application.Appointments.Repository;
using SaudeSemFronteiras.Application.Specialities.Commands;
using System;

namespace SaudeSemFronteiras.Application.Appointments.Handlers;
public class AppointmentHandler : IRequestHandler<CreateAppointmentCommand, Result>,
                                  IRequestHandler<ChangeAppointmentCommand, Result>,
                                  IRequestHandler<DeleteAppointmentCommand, Result>
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

        var appointmentCount = _appointmentQueries.GetAppointmentByDate(request.Date, cancellationToken);
        if (appointmentCount.Result > 0)
            return Result.Failure("Já existe consulta para essa data.");

        if (request.Date < DateTime.Now)
            return Result.Failure("Não é possível agendar com data anterior a hoje.");

        var appointment = Appointment.Create(request.Date, request.Duration, request.DoctorId, request.PatientId);

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

        appointment.Update(request.Date, request.Duration,request.DoctorId, request.PatientId);

        await _appointmentRepository.Update(appointment, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        await _appointmentRepository.Delete(request.Id, cancellationToken);

        return Result.Success();
    }
}
