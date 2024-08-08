using Dapper;
using SaudeSemFronteiras.Application.Phones.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Phones.Repository;
public class PhoneRepository(IDatabaseFactory LocalDatabase) : IPhoneRepository
{
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
