using SaudeSemFronteiras.Application.Login.Domain;

namespace SaudeSemFronteiras.Application.Login.Repository;
public interface ICredentialsRepository
{
    Task<Credentials?> GetById(long iD, CancellationToken cancellationToken);
    Task Insert(Credentials credentials, CancellationToken cancellationToken);
    Task Update(Credentials credentials, CancellationToken cancellationToken);
}
