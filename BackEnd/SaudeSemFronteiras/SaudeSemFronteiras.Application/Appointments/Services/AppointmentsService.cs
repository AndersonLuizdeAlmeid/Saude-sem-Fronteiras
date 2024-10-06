using CSharpFunctionalExtensions;
using SaudeSemFronteiras.Application.Appointments.Dtos;
using SaudeSemFronteiras.Application.Appointments.Queries;
using SaudeSemFronteiras.Application.Doctors.Queries;
using SaudeSemFronteiras.Common.Utils;

namespace SaudeSemFronteiras.Application.Appointments.Services;

public class AppointmentsService
{
    private readonly IAppointmentQueries _appointmentQueries;
    private readonly IDoctorQueries _doctorQueries;

    public AppointmentsService(IAppointmentQueries appointmentQueries, IDoctorQueries doctorQueries)
    {
        _appointmentQueries = appointmentQueries;
        _doctorQueries = doctorQueries;
    }

    public IEnumerable<string> GetAllFreeTimeOfAppointmentsByDoctor(long doctor_id, DateOnly date, CancellationToken cancellationToken)
    {
        var appointments = _appointmentQueries.GetAllFreeTimeByDoctor(doctor_id, date, cancellationToken);
        if (appointments.Result == null)
            appointments = (Task<IEnumerable<AppointmentDto>>)Enumerable.Empty<AppointmentDto>();
        var doctor = _doctorQueries.GetDtoById(doctor_id, cancellationToken);

        if (doctor == null)
            throw new Exception("Médico não encontrado.");

        var freeSlots = new List<string>();
        if (!TimeSpan.TryParse(doctor.Result.InitialHour, out var initialHour) ||
        !TimeSpan.TryParse(doctor.Result.FinalHour, out var finalHour))
        {
            throw new Exception("Horários inválidos.");
        }

        var validateDate = ValidateDay.ValidateWorkingDay(date, doctor.Result.Days);
        if (validateDate.IsFailure)
            return null;

        // Criar uma lista de todos os horários possíveis de consulta (de hora em hora)
        for (var hour = initialHour; hour < finalHour; hour = hour.Add(TimeSpan.FromHours(1)))
        {
            freeSlots.Add(hour.ToString(@"hh\:mm")); // Adiciona o horário formatado
        }

        // Excluir os horários ocupados
        foreach (var appointment in appointments.Result)
        {
            var appointmentTime = appointment.Date.TimeOfDay;
            freeSlots.Remove(appointmentTime.ToString(@"hh\:mm"));
        }

        return freeSlots;
    }
}
