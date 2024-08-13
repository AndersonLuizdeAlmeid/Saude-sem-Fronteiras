using Dapper;
using SaudeSemFronteiras.Application.Login.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Login.Repository;
public class CredentialsRepository(IDatabaseFactory LocalDatabase) : ICredentialsRepository
{
    public async Task Insert(Credentials credentials, CancellationToken cancellationToken)
    {
        var sql = @"insert into logins(email, password, user_id) 
                    values (@Email, @Password, @UserId)";

        var command = new CommandDefinition(sql, credentials, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Credentials credentials, CancellationToken cancellationToken)
    {
        var sql = @"update logins
                       set email = @Email,
                           password = @Password,
                           user_id = @UserId
                     where id = @ID";

        var command = new CommandDefinition(sql, credentials, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
