using SaudeSemFronteiras.Common.Factory.Interfaces;
using Dapper;

namespace SaudeSemFronteiras.Common.DataBase;
public class Tables(IDatabaseFactory databaseFactory)
{
    private readonly IDatabaseFactory _databaseFactory = databaseFactory;

    public async Task CreateUsersTable(CancellationToken cancellationToken)
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        Users (
                            id BIGINT PRIMARY KEY,
                            name VARCHAR(255) NOT NULL,
                            cpf VARCHAR(14) NOT NULL,
                            mother_name VARCHAR(255) NOT NULL,
                            date_birth TIMESTAMP NOT NULL,
                            date_of_creation TIMESTAMP NOT NULL,
                            language VARCHAR(50) NOT NULL,
                            isActive BOOLEAN NOT NULL
                        )";

        var command = new CommandDefinition(sql, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        await _databaseFactory.Connection.ExecuteAsync(command);
    }

    public async Task CreateLoginsTable(CancellationToken cancellationToken)
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        Logins (
                            id BIGINT PRIMARY KEY,
                            email VARCHAR(255) NOT NULL,
                            password VARCHAR(255) NOT NULL
                        )";

        var command = new CommandDefinition(sql, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        await _databaseFactory.Connection.ExecuteAsync(command);

    }
}
