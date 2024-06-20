using SaudeSemFronteiras.Application.Users.Domain;

namespace SaudeSemFronteiras.Application.Users.Repository;
public interface IUserRepository
{
    Task<User?> GetByID(long iD, CancellationToken cancellationToken);
    Task Insert(User user, CancellationToken cancellationToken);
    Task Update(User user, CancellationToken cancellationToken);
}
