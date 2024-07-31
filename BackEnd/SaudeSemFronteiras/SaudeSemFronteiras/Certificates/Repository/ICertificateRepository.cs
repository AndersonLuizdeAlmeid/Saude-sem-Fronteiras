using SaudeSemFronteiras.Application.Certificates.Domain;

namespace SaudeSemFronteiras.Application.Certificates.Repository;
public interface ICertificateRepository
{
    Task<Certificate?> GetByID(long iD, CancellationToken cancellationToken);
    Task Insert(Certificate certificate, CancellationToken cancellationToken);
    Task Update(Certificate certificate, CancellationToken cancellationToken);
}
