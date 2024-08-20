using SaudeSemFronteiras.Common.Repository;

namespace SaudeSemFronteiras.Application.Database.Repository;
public interface IDatabaseInsertsRepository : ILocalDatabaseRepository
{
    Task InsertCountriesRecords();
    Task InsertStatesRecords();
    Task InsertCitiesRecords();
}
