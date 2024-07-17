using SaudeSemFronteiras.Application.Login.Dtos;

namespace SaudeSemFronteiras.Application.Login.Queries;
public interface ICredentialsQueries
{
    Task<CredentialsDto?> GetByEmailAndPassword(string email, string password, CancellationToken cancellationToken);
    Task<int> GetIfEmailExists(string email, CancellationToken cancellationToken);
    Task<IEnumerable<CredentialsDto>> GetAll(CancellationToken cancellationToken);
}
