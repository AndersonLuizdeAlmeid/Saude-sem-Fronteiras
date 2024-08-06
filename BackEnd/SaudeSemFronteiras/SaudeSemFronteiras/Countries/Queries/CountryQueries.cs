using Dapper;
using SaudeSemFronteiras.Application.Countries.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Countries.Queries;
public class CountryQueries(IDatabaseFactory databaseFactory) : ICountryQueries
{
    private readonly IDatabaseFactory _databaseFactory = databaseFactory;

    public async Task<IEnumerable<CountryDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as ID, 
                           description as Description
                      FROM countries ";

        var command = new CommandDefinition(sql, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryAsync<CountryDto>(command);
    }

    public async Task<CountryDto> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as ID, 
                           description as Description
                      FROM countries
                     WHERE id = @iD ";

        var command = new CommandDefinition(sql, new { iD }, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryFirstAsync<CountryDto>(command);
    }
}
