using SaudeSemFronteiras.Application.Appointments.Domain;
namespace SaudeSemFronteiras.Application.Appointments.Repository;
public interface IAppointmentRepository
{
    Task Insert(Appointment appointment, CancellationToken cancellationToken);
    Task Update(Appointment appointment, CancellationToken cancellationToken);
    Task Delete(long iD, CancellationToken cancellationToken);
}
