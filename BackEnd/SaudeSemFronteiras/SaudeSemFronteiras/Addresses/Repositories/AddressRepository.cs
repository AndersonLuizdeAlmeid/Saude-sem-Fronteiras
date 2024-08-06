using Dapper;
using SaudeSemFronteiras.Application.Addresses.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Addresses.Repositories;
public class AddressRepository(IDatabaseFactory LocalDatabase) : IAddressRepository
{
    public async Task<Address?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           district as District, 
                           street as Street, 
                           number as Number,
                           complement as Complement,
                           city_id as CityId
                      from addresses
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Address>(command);
    }

    public async Task Insert(Address address, CancellationToken cancellationToken)
    {
        var sql = @"insert into addresses(id, district, street, number, complement, city_id) 
                    values (@Id, @District, @Street, @Number, @Complement, @CityId)";

        var command = new CommandDefinition(sql, address, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Address address, CancellationToken cancellationToken)
    {
        var sql = @"update addresses
                       set district = @District,
                           street = @Street,
                           number = @Number,
                           complement = @Complement,
                           city_id = @CityId
                     where id = @Id"
        ;

        var command = new CommandDefinition(sql, address, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
