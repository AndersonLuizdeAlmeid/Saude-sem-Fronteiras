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

    public async Task CreateLoginsTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        logins (
                            id SERIAL PRIMARY KEY NOT NULL,
                            email VARCHAR(255) NOT NULL,
                            password VARCHAR(255) NOT NULL
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);

    }

    public async Task CreateUsersTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        users (
                            id SERIAL PRIMARY KEY NOT NULL,
                            name VARCHAR(255) NOT NULL,
                            cpf VARCHAR(14) NOT NULL,
                            mother_name VARCHAR(255) NOT NULL,
                            date_birth TIMESTAMP NOT NULL,
                            date_of_creation TIMESTAMP NOT NULL,
                            language VARCHAR(50) NOT NULL,
                            is_active BOOLEAN NOT NULL,
                            address_id BIGINT,
                            FOREIGN KEY (address_id) REFERENCES addresses(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreatePhonesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        phones (
                            id SERIAL PRIMARY KEY NOT NULL,
                            number VARCHAR(255) NOT NULL,
                            user_id BIGINT,
                            FOREIGN KEY (user_id) REFERENCES users(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);

    }

    public async Task CreateCountriesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        countries (
                            id SERIAL PRIMARY KEY NOT NULL,
                            description VARCHAR(255) NOT NULL
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateStatesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        states (
                            id SERIAL PRIMARY KEY NOT NULL,
                            description VARCHAR(255) NOT NULL,
                            country_id BIGINT,
                            FOREIGN KEY (country_id) REFERENCES countries(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateCitiesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        cities (
                            id SERIAL PRIMARY KEY NOT NULL,
                            description VARCHAR(255) NOT NULL,
                            state_id BIGINT,
                            FOREIGN KEY (state_id) REFERENCES states(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateAddressesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        addresses (
                            id SERIAL PRIMARY KEY NOT NULL,
                            district VARCHAR(255) NOT NULL,
                            street VARCHAR(255) NOT NULL,
                            number VARCHAR(10) NOT NULL,
                            complement VARCHAR(255),
                            city_id BIGINT,
                            FOREIGN KEY (city_id) REFERENCES cities(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }
}
