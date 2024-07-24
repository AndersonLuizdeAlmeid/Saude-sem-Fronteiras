using Dapper;
using SaudeSemFronteiras.Application.Specialities.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Specialities.Repository;
public class SpecialityRepository(IDatabaseFactory LocalDatabase) : ISpecialityRepository
{
    public async Task<Speciality?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           description as Description, 
                           is_active as IsActive,
                      from specialities
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Speciality>(command);
    }

    public async Task Insert(Speciality speciality, CancellationToken cancellationToken)
    {
        var sql = @"insert into specialities(description, is_active) 
                                 values (@Description, @IsActive)";
        var command = new CommandDefinition(sql, speciality, transaction:  LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Speciality speciality, CancellationToken cancellationToken)
    {
        var sql = @"update specialities
                       set description = @Description, 
                           is_active = @IsActive
                     where id = @Id";

        var command = new CommandDefinition(sql, speciality, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
