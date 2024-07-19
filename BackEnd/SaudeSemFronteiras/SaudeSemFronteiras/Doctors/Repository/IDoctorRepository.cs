using SaudeSemFronteiras.Application.Doctors.Domain;

namespace SaudeSemFronteiras.Application.Doctors.Repository;
public interface IDoctorRepository
{
    Task<Doctor?> GetById(long iD, CancellationToken cancellationToken);
    Task Insert(Doctor doctor, CancellationToken cancellationToken);
    Task Update(Doctor doctor, CancellationToken cancellationToken);
}
