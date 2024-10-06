using SaudeSemFronteiras.Application.Medicines.Domain;
using SaudeSemFronteiras.Application.Medicines.Dtos;

namespace SaudeSemFronteiras.Application.Medicines.Queries;
public interface IMedicineQueries
{
    Task<IEnumerable<MedicineDto>> GetAll(CancellationToken cancellationToken);
    Task<Medicine?> GetById(long iD, CancellationToken cancellationToken);
}
