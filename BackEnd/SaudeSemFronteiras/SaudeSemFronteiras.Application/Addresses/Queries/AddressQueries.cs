using Dapper;
using SaudeSemFronteiras.Application.Addresses.Domain;
using SaudeSemFronteiras.Application.Addresses.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Addresses.Queries;
public class AddressQueries(IDatabaseFactory databaseFactory) : IAddressQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<AddressDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as ID,
                           district as District, 
                           street as Street, 
                           number as Number,
                           complement as Complement,
                           city_id as CityId,
                           user_id as UserId
                      FROM addresses ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<AddressDto>(command);
    }

    public async Task<Address?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           district as District, 
                           street as Street, 
                           number as Number,
                           complement as Complement,
                           city_id as CityId,
                           user_id as UserId
                      from addresses
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Address>(command);
    }

    public async Task<AddressDto?> GetByUserId(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           district as District, 
                           street as Street, 
                           number as Number,
                           complement as Complement,
                           city_id as CityId,
                           user_id as UserId
                      from addresses
                     where user_id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<AddressDto>(command);
    }
}
