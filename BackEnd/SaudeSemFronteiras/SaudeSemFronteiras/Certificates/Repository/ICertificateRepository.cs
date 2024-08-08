using SaudeSemFronteiras.Application.Certificates.Domain;

namespace SaudeSemFronteiras.Application.Certificates.Repository;
public interface ICertificateRepository
{
    Task Insert(Certificate certificate, CancellationToken cancellationToken);
    Task Update(Certificate certificate, CancellationToken cancellationToken);
}
