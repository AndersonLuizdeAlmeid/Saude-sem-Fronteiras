using Dapper;
using SaudeSemFronteiras.Application.Addresses.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Addresses.Repositories;
public class AddressRepository(IDatabaseFactory LocalDatabase) : IAddressRepository
{
    public async Task Insert(Address address, CancellationToken cancellationToken)
    {
        var sql = @"insert into addresses(district, street, number, complement, city_id, user_id) 
                    values (@District, @Street, @Number, @Complement, @CityId, @UserId)";

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
                           city_id = @CityId,
                           user_id = @UserId
                     where id = @Id"
        ;

        var command = new CommandDefinition(sql, address, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
