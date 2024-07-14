using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Common.Repository;
public interface ILocalDatabaseRepository
{
    IDatabaseFactory LocalDatabase { get; }
}
