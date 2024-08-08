using SaudeSemFronteiras.Application.Patients.Domain;

namespace SaudeSemFronteiras.Application.Patients.Repository;
public interface IPatientRepository
{
    Task Insert(Patient patient, CancellationToken cancellationToken);
    Task Update(Patient patient, CancellationToken cancellationToken);
}
