using Dapper;
using SaudeSemFronteiras.Application.Login.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Login.Queries;
public class CredentialsQueries(IDatabaseFactory _databaseFactory) : ICredentialsQueries
{
    public async Task<CredentialsDto?> GetByEmailAndPassword(string email, string password, CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as ID, 
                           email as Email, 
                           password as Password
                      FROM logins
                     where email = @email
                       and password = @password";

        var command = new CommandDefinition(sql, new { email, password }, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryFirstOrDefaultAsync<CredentialsDto>(command);
    }

    public async Task<int> GetIfEmailExists(string email, CancellationToken cancellationToken)
    {
        var sql = @"SELECT count(id)
                      FROM logins
                     where email = @email";

        var command = new CommandDefinition(sql, new { email }, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryFirstOrDefaultAsync<int>(command);
    }

    public async Task<IEnumerable<CredentialsDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as ID, 
                           email as Email, 
                           password as Password
                      FROM logins
                     where email = @email
                       and password = @password";

        var command = new CommandDefinition(sql, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryAsync<CredentialsDto>(command);
    }
}
