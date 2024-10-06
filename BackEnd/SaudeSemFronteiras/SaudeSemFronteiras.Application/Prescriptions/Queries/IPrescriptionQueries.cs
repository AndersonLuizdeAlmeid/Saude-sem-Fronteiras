using SaudeSemFronteiras.Application.Prescriptions.Domain;
using SaudeSemFronteiras.Application.Prescriptions.Dtos;

namespace SaudeSemFronteiras.Application.Prescriptions.Queries;
public interface IPrescriptionQueries
{
    Task<IEnumerable<PrescriptionDto>> GetAll(CancellationToken cancellationToken);
    Task<Prescription?> GetByID(long iD, CancellationToken cancellationToken);
    Task<PrescriptionDto?> GetPrescriptionByDocumentIdQuery(long iD, CancellationToken cancellationToken);
    Task<IEnumerable<PrescriptionShowDto>> GetPrescriptionShowByDocumentIdQuery(long documentId, CancellationToken cancellationToken);
    Task<long?> GetPrescriptionIdByDocumentIdQuery(long iD, CancellationToken cancellationToken);
}
