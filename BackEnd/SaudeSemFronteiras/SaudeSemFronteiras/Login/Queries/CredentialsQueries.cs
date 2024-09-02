using Dapper;
using SaudeSemFronteiras.Application.Login.Domain;
using SaudeSemFronteiras.Application.Login.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Login.Queries;
public class CredentialsQueries(IDatabaseFactory _databaseFactory) : ICredentialsQueries
{

    public async Task<int> GetIfEmailExists(string email, CancellationToken cancellationToken)
    {
        var sql = @"SELECT count(id)
                      FROM credentials
                     where email = @email";

        var command = new CommandDefinition(sql, new { email }, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryFirstOrDefaultAsync<int>(command);
    }

    public async Task<CredentialsDto?> GetCredentialsByEmailAndPassword(string email, string password, CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as ID, 
                           email as Email, 
                           password as Password
                      FROM credentials
                     where email = @email
                       and password = @password";

        var command = new CommandDefinition(sql, new { email, password }, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryFirstAsync<CredentialsDto>(command);
    }

    public async Task<Credentials?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as ID, 
                           email as Email, 
                           password as Password
                      from credentials
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryFirstOrDefaultAsync<Credentials>(command);
    }
}
