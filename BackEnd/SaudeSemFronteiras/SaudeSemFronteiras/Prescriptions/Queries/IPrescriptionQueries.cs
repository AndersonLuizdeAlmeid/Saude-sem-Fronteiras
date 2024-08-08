using SaudeSemFronteiras.Application.Prescriptions.Domain;
using SaudeSemFronteiras.Application.Prescriptions.Dtos;

namespace SaudeSemFronteiras.Application.Prescriptions.Queries;
public interface IPrescriptionQueries
{
    Task<IEnumerable<PrescriptionDto>> GetAll(CancellationToken cancellationToken);
    Task<Prescription?> GetByID(long iD, CancellationToken cancellationToken);

}
