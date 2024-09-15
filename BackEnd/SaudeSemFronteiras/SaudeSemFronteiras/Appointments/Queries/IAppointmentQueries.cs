using SaudeSemFronteiras.Application.Appointments.Domain;
using SaudeSemFronteiras.Application.Appointments.Dtos;

namespace SaudeSemFronteiras.Application.Appointments.Queries;
public interface IAppointmentQueries
{
    Task<IEnumerable<AppointmentDto>> GetAll(CancellationToken cancellationToken);
    Task<Appointment?> GetById(long iD, CancellationToken cancellationToken);
    Task<int> GetAppointmentByDate(DateTime date, CancellationToken cancellationToken);
    Task<IEnumerable<AppointmentDto?>> GetAllFreeTimeByDoctor(long iD, DateOnly date, CancellationToken cancellationToken);
    Task<IEnumerable<AppointmentShowDto?>> GetAppointmentsByPatientId(long patientId, CancellationToken cancellationToken);
}
