using Dapper;
using SaudeSemFronteiras.Application.Users.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Users.Repository;
public class UserRepository(IDatabaseFactory LocalDatabase) : IUserRepository
{


    public async Task Insert(User user, CancellationToken cancellationToken)
    {
        var sql = @"insert into users(name, cpf, mother_name, date_birth, date_of_creation, gender, language, is_active, credentials_id) 
                    values (@Name, @CPF, @MotherName, @DateBirth, @DateOfCreation, @Gender, @Language, @IsActive, @CredentialsId)";

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
                           gender = @Gender,
                           language = @Language,
                           is_active = @IsActive
                     where id = @Id";

        var command = new CommandDefinition(sql, user, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
