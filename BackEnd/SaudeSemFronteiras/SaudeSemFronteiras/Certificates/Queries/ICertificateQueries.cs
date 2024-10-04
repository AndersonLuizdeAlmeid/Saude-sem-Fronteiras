using SaudeSemFronteiras.Application.Certificates.Domain;
using SaudeSemFronteiras.Application.Certificates.Dtos;

namespace SaudeSemFronteiras.Application.Certificates.Queries;

public interface ICertificateQueries
{
    Task<IEnumerable<CertificateDto>> GetAll(CancellationToken cancellationToken);
    Task<Certificate?> GetByID(long iD, CancellationToken cancellationToken);
    Task<CertificateShowDto?> GetByIdDtoQuery(long iD, CancellationToken cancellationToken);
    Task<CertificateDto?> GetCertificateByDocumentIdQuery(long iD, CancellationToken cancellationToken);
}
