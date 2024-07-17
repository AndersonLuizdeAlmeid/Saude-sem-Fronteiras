using Dapper;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Database.Repository;
public class DatabaseRepository : IDatabaseRepository
{
    public IDatabaseFactory LocalDatabase { get; }


    public DatabaseRepository(IDatabaseFactory databaseFactory)
    {
        LocalDatabase = databaseFactory;
    }


    public async Task CreateUsersTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        Users (
                            id SERIAL PRIMARY KEY NOT NULL,
                            name VARCHAR(255) NOT NULL,
                            cpf VARCHAR(14) NOT NULL,
                            mother_name VARCHAR(255) NOT NULL,
                            date_birth TIMESTAMP NOT NULL,
                            date_of_creation TIMESTAMP NOT NULL,
                            language VARCHAR(50) NOT NULL,
                            isActive BOOLEAN NOT NULL
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateLoginsTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        Logins (
                            id SERIAL PRIMARY KEY NOT NULL,
                            email VARCHAR(255) NOT NULL,
                            password VARCHAR(255) NOT NULL
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);

    }

    public async Task CreateAddressesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        Addresses (
                            id SERIAL PRIMARY KEY NOT NULL,
                            district VARCHAR(255) NOT NULL,
                            street VARCHAR(255) NOT NULL,
                            number VARCHAR(10) NOT NULL,
                            complement VARCHAR(255),
                            city_id BIGINT FOREIGN KEY
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);

    }
}
