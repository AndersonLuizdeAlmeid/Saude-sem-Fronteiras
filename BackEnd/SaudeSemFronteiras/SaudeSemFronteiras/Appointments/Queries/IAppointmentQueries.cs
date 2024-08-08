using SaudeSemFronteiras.Application.Appointments.Domain;
using SaudeSemFronteiras.Application.Appointments.Dtos;

namespace SaudeSemFronteiras.Application.Appointments.Queries;
public interface IAppointmentQueries
{
    Task<IEnumerable<AppointmentDto>> GetAll(CancellationToken cancellationToken);
    Task<Appointment?> GetById(long iD, CancellationToken cancellationToken);
}
