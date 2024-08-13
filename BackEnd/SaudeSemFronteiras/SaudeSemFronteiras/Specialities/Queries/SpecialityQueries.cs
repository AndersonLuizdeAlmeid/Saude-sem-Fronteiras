using Dapper;
using SaudeSemFronteiras.Application.Specialities.Domain;
using SaudeSemFronteiras.Application.Specialities.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Specialities.Queries;
public class SpecialityQueries(IDatabaseFactory databaseFactory) : ISpecialityQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;
   
    public async Task<IEnumerable<SpecialityDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as ID,
                           description as Description,
                           is_active as IsActive,
                           doctor_id as DoctorId
                      FROM specialities ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<SpecialityDto>(command);
    }

    public async Task<Speciality?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           description as Description, 
                           is_active as IsActive,
                           doctor_id as DoctorId
                      from specialities
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Speciality>(command);
    }
}
