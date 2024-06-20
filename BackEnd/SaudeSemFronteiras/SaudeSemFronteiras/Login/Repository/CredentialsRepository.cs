using Dapper;
using SaudeSemFronteiras.Application.Login.Domain;
using SaudeSemFronteiras.Application.Users.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Login.Repository;
public class CredentialsRepository(IDatabaseFactory LocalDatabase) : ICredentialsRepository
{
    public async Task<Credentials?> GetByID(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as ID, 
                           email as Email, 
                           password as Password
                      from credentials
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Credentials>(command);
    }

    public async Task Insert(Credentials credentials, CancellationToken cancellationToken)
    {
        var sql = @"insert into credentials(email, password) 
                    values (@Email, @Password)";

        var command = new CommandDefinition(sql, credentials, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Credentials credentials, CancellationToken cancellationToken)
    {
        var sql = @"update credentials
                       set email = @Email,
                           password = @Password
                     where id = @ID";

        var command = new CommandDefinition(sql, credentials, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
