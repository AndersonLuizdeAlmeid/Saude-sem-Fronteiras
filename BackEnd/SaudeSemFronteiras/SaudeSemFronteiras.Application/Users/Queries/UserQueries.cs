using Dapper;
using SaudeSemFronteiras.Application.Users.Domain;
using SaudeSemFronteiras.Application.Users.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Users.Queries;
public class UserQueries(IDatabaseFactory databaseFactory) : IUserQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<UserDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as ID,
                           name as Name,
                           cpf as CPF,
                           motherName as MotherName,
                           dateBirth as DateBirth,
                           gender as Gender,
                           language as Language,
                           is_active as IsActive,
                           phone as Phone,
                           credentials_id as CredentialsId
                      FROM users ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<UserDto>(command);
    }

    public async Task<UserDto?> GetByID(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           name as Name, 
                           cpf as CPF, 
                           mother_name as MotherName,
                           date_birth as DateBirth,
                           date_of_creation as DateOfCreation,
                           gender as Gender,
                           language as Language,
                           is_active as IsActive,
                           phone as Phone,
                           credentials_id as CredentialsId
                      from users
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<UserDto>(command);
    }

    public async Task<long> GetIdByCpf(string cpf, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id
                      from users
                     where cpf = @cpf";

        var command = new CommandDefinition(sql, new { cpf }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<long>(command);
    }

    public async Task<long> GetLastCreateId(CancellationToken cancellationToken)
    {
        var sql = @"select max(id) as Id
                      from users ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<long>(command);
    }

    public async Task<UserDto?> GetUserByCredentialsId(long id, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           name as Name, 
                           cpf as CPF, 
                           mother_name as MotherName,
                           date_birth as DateBirth,
                           gender as Gender,
                           language as Language,
                           is_active as IsActive,
                           phone as Phone,
                           credentials_id as CredentialsId
                      from users
                     where credentials_id = @id";

        var command = new CommandDefinition(sql, new { id }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<UserDto>(command);
    }

    public async Task<UserDto?> GetUserByUserId(long id, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           name as Name, 
                           cpf as CPF, 
                           mother_name as MotherName,
                           date_birth as DateBirth,
                           gender as Gender,
                           language as Language,
                           is_active as IsActive,
                           phone as Phone,
                           credentials_id as CredentialsId
                      from users
                     where id = @id";

        var command = new CommandDefinition(sql, new { id }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<UserDto>(command);
    }
}
