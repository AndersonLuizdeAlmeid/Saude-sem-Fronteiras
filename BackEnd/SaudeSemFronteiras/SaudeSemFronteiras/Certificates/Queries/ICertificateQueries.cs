using SaudeSemFronteiras.Application.Certificates.Domain;
using SaudeSemFronteiras.Application.Certificates.Dtos;

namespace SaudeSemFronteiras.Application.Certificates.Queries;

public interface ICertificateQueries
{
    Task<IEnumerable<CertificateDto>> GetAll(CancellationToken cancellationToken);
    Task<Certificate?> GetByID(long iD, CancellationToken cancellationToken);
}
