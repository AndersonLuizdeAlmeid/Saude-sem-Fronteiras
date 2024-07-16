using SaudeSemFronteiras.Common.Repository;

namespace SaudeSemFronteiras.Application.Database.Repository;
public interface IDatabaseRepository : ILocalDatabaseRepository
{
    Task CreateLoginsTable();
    Task CreateUsersTable();
    Task CreateAddressesTable();
}
