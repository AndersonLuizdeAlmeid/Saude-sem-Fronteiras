using SaudeSemFronteiras.Application.Login.Domain;

namespace SaudeSemFronteiras.Application.Login.Repository;
public interface ICredentialsRepository
{
    Task Insert(Credentials credentials, CancellationToken cancellationToken);
    Task Update(Credentials credentials, CancellationToken cancellationToken);
}
