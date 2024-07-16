using Dapper;
using SaudeSemFronteiras.Application.Users.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Users.Repository;
public class UserRepository(IDatabaseFactory LocalDatabase) : IUserRepository
{
    public async Task<User?> GetByID(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           name as Name, 
                           cpf as CPF, 
                           mother_name as MotherName,
                           date_birth as DateBirth,
                           date_of_creation as DateOfCreation,
                           language as Language,
                           is_active as IsActive
                      from users
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<User>(command);
    }

    public async Task Insert(User user, CancellationToken cancellationToken)
    {
        var sql = @"insert into users(name, cpf, mother_name, date_birth, date_of_creation, language, is_active) 
                    values (@Name, @CPF, @MotherName, @DateBirth, @Language, @DateOfCreation, @IsActive)";

        var command = new CommandDefinition(sql, user, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(User user, CancellationToken cancellationToken)
    {
        var sql = @"update users
                       set name = @Name,
                           cpf = @CPF,
                           mother_name = @MotherName,
                           date_birth = @DateBirth,
                           language = @Language,
                           is_active = @IsActive
                     where id = @Id";

        var command = new CommandDefinition(sql, user, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
