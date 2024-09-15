using SaudeSemFronteiras.Application.Login.Domain;
using SaudeSemFronteiras.Application.Login.Dtos;

namespace SaudeSemFronteiras.Application.Login.Queries;
public interface ICredentialsQueries
{
    Task<int> GetIfEmailExists(string email, CancellationToken cancellationToken);
    Task<CredentialsDto?> GetDataCredentialsByEmail(string email, CancellationToken cancellationToken);
    Task<Credentials?> GetById(long iD, CancellationToken cancellationToken);
    Task<CredentialsDto?> GetCredentialsByEmailAndPassword(string email, string password, CancellationToken cancellationToken);
}
