using SaudeSemFronteiras.Application.Users.Domain;
using SaudeSemFronteiras.Application.Users.Dtos;

namespace SaudeSemFronteiras.Application.Users.Queries;
public interface IUserQueries
{
    Task<IEnumerable<UserDto>>GetAll(CancellationToken cancellationToken);
    Task<UserDto?> GetByID(long iD, CancellationToken cancellationToken);
    Task<long> GetIdByCpf(string cpf, CancellationToken cancellationToken);
    Task<long> GetLastCreateId(CancellationToken cancellationToken);
    Task<UserDto?> GetUserByCredentialsId(long iD, CancellationToken cancellationToken);
}