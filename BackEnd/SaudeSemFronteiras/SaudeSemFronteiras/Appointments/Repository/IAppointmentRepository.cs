using SaudeSemFronteiras.Application.Appointments.Domain;
using SaudeSemFronteiras.Application.Users.Domain;

namespace SaudeSemFronteiras.Application.Appointments.Repository;
public interface IAppointmentRepository
{
    Task<Appointment?> GetById(long iD, CancellationToken cancellationToken);
    Task Insert(Appointment appointment, CancellationToken cancellationToken);
    Task Update(Appointment appointment, CancellationToken cancellationToken);
}
