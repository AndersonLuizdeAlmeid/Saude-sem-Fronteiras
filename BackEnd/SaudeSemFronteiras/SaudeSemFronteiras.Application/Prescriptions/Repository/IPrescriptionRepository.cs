using SaudeSemFronteiras.Application.Prescriptions.Domain;

namespace SaudeSemFronteiras.Application.Prescriptions.Repository;
public interface IPrescriptionRepository
{
    Task Insert(Prescription prescription, CancellationToken cancellationToken);
    Task Update(Prescription prescription, CancellationToken cancellationToken);
    Task Delete(long iD, CancellationToken cancellationToken);
}
