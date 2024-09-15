using Dapper;
using SaudeSemFronteiras.Application.States.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.States.Queries;
public class StateQueries(IDatabaseFactory databaseFactory) :IStateQueries
{
    private readonly IDatabaseFactory _databaseFactory = databaseFactory;

    public async Task<IEnumerable<StateDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           description as Description,
                           country_id as CountryId
                      FROM states ";

        var command = new CommandDefinition(sql, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryAsync<StateDto>(command);
    }

    public async Task<StateDto> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           description as Description,
                           country_id as CountryId
                      FROM states
                     WHERE id = @iD ";

        var command = new CommandDefinition(sql, new { iD }, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryFirstAsync<StateDto>(command);
    }

    public async Task<IEnumerable<StateDto>> GetByCountryId(long countryId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           description as Description,
                           country_id as CountryId
                      FROM states
                     WHERE country_id = @countryId ";

        var command = new CommandDefinition(sql, new { countryId }, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryAsync<StateDto>(command);
    }
}
