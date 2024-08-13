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
                           language as Language,
                           is_active as IsActive,
                           address_id as AddressId
                      FROM users ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<UserDto>(command);
    }

    public async Task<User?> GetByID(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           name as Name, 
                           cpf as CPF, 
                           mother_name as MotherName,
                           date_birth as DateBirth,
                           date_of_creation as DateOfCreation,
                           language as Language,
                           is_active as IsActive,
                           address_id as AddressId
                      from users
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<User>(command);
    }
}
