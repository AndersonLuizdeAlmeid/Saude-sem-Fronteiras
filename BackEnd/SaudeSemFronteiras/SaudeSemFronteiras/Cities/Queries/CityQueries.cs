using Dapper;
using SaudeSemFronteiras.Application.Cities.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Cities.Queries;
public class CityQueries(IDatabaseFactory databaseFactory) : ICityQueries
{
    private readonly IDatabaseFactory _databaseFactory = databaseFactory;

    public async Task<IEnumerable<CityDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as ID, 
                           description as Description
                      FROM cities ";

        var command = new CommandDefinition(sql, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryAsync<CityDto>(command);
    }

    public async Task<CityDto> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as ID, 
                           description as Description,
                           id_state as StateId
                      FROM cities
                     WHERE id = @iD ";

        var command = new CommandDefinition(sql, new { iD }, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryFirstAsync<CityDto>(command);
    }

    public async Task<IEnumerable<CityDto>> GetByStateId(long stateId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as ID, 
                           description as Description,
                           id_state as StateId
                      FROM cities
                     WHERE id_state = @stateId ";

        var command = new CommandDefinition(sql, new { stateId }, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryAsync<CityDto>(command);
    }

}
