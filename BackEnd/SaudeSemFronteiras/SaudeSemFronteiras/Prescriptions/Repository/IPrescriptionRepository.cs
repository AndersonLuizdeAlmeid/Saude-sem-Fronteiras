using SaudeSemFronteiras.Application.Prescriptions.Domain;

namespace SaudeSemFronteiras.Application.Prescriptions.Repository;
public interface IPrescriptionRepository
{
    Task<Prescription?> GetByID(long iD, CancellationToken cancellationToken);
    Task Insert(Prescription prescription, CancellationToken cancellationToken);
    Task Update(Prescription prescription, CancellationToken cancellationToken);
}
