using SaudeSemFronteiras.Application.Appointments.Dtos;
using SaudeSemFronteiras.Application.Scheduled.Domain;
using SaudeSemFronteiras.Application.Scheduled.Dtos;

namespace SaudeSemFronteiras.Application.Scheduled.Queries;
public interface IScheduleQueries
{
    Task<IEnumerable<ScheduleDto>> GetAll(CancellationToken cancellationToken);
    Task<ScheduleDto?> GetById(long iD, CancellationToken cancellationToken);
    Task<IEnumerable<ScheduleShowDto?>> GetAppointmentsByPatientId(long patientId, CancellationToken cancellationToken);
    Task<IEnumerable<ScheduleShowDto?>> GetAppointmentsByDoctorId(long doctorId, CancellationToken cancellationToken);
    Task<string> GetPhoneByDoctorQuery(long scheduleId, CancellationToken cancellationToken);
    Task<string> GetPhoneByPatientQuery(long scheduleId, CancellationToken cancellationToken);
}
