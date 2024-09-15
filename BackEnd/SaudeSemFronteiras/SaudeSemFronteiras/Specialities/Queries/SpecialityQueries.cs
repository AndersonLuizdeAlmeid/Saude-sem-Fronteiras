using Dapper;
using SaudeSemFronteiras.Application.Specialities.Domain;
using SaudeSemFronteiras.Application.Specialities.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Specialities.Queries;
public class SpecialityQueries(IDatabaseFactory databaseFactory) : ISpecialityQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;
   
    public async Task<IEnumerable<SpecilitiesShowDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id,
                           description as Description
                      FROM specialities 
                     WHERE is_active = 'true'";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<SpecilitiesShowDto>(command);
    }

    public async Task<IEnumerable<SpecilitiesShowDto>> GetAllSpecialitiesByDoctorId(long doctorId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id,
                           description as Description
                      FROM specialities 
                     WHERE doctor_id = @doctorId";

        var command = new CommandDefinition(sql, new { doctorId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<SpecilitiesShowDto>(command);
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
