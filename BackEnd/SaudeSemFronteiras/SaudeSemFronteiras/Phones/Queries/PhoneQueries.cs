using Dapper;
using SaudeSemFronteiras.Application.Phones.Domain;
using SaudeSemFronteiras.Application.Phones.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Phones.Queries;

public class PhoneQueries(IDatabaseFactory databaseFactory) : IPhoneQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<PhoneDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           number as Number,
                           user_id as UserId
                      FROM phones ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<PhoneDto>(command);
    }

    public async Task<IEnumerable<PhoneDataDto>> GetAllPhonesByUserId(long userId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           number as Number
                      FROM phones 
                     WHERE user_id = @userId";

        var command = new CommandDefinition(sql, new { userId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<PhoneDataDto>(command);
    }

    public async Task<Phone?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           number as Number,
                           user_id as UserId
                      from phones
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Phone>(command);
    }

}
