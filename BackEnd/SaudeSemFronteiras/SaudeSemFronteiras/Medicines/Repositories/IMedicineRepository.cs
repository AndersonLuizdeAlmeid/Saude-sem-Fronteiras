using SaudeSemFronteiras.Application.Medicines.Domain;

namespace SaudeSemFronteiras.Application.Medicines.Repositories;
public interface IMedicineRepository
{
    Task Insert(Medicine medicine, CancellationToken cancellationToken);
    Task Delete(long iD, CancellationToken cancellationToken);
}
