using Dapper;
using SaudeSemFronteiras.Application.Phones.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Phones.Repository;
public class PhoneRepository(IDatabaseFactory LocalDatabase) : IPhoneRepository
{
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

    public async Task Insert(Phone phone, CancellationToken cancellationToken)
    {
        var sql = @"insert into phones(number, user_id) 
                                 values (@Number, @UserId)";
        var command = new CommandDefinition(sql, phone, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Phone phone, CancellationToken cancellationToken)
    {
        var sql = @"update phones
                       set number = @Number,
                           user_id = @UserId
                     where id = @Id";

        var command = new CommandDefinition(sql, phone, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
