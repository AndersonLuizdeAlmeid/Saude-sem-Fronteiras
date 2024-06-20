using Dapper;
using SaudeSemFronteiras.Application.Users.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Users.Queries;
public class UserQueries(IDatabaseFactory databaseFactory) : IUserQueries
{
    private readonly IDatabaseFactory _databaseFactory = databaseFactory;

    public async Task<IEnumerable<UserDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as ID, 
                           name as Name, 
                           cpf as CPF, 
                           motherName as MotherName, 
                           dateBirth as DateBirth,
                           language as Language,
                           is_active as IsActive
                      FROM users";

        var command = new CommandDefinition(sql, transaction: _databaseFactory.Transaction, cancellationToken: cancellationToken);
        return await _databaseFactory.Connection.QueryAsync<UserDto>(command);
    }
}
