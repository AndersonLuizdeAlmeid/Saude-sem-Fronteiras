using Dapper;
using SaudeSemFronteiras.Application.Screenings.Domain;
using SaudeSemFronteiras.Application.Screenings.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Screenings.Queries;
public class ScreeningQueries(IDatabaseFactory databaseFactory) : IScreeningQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<ScreeningDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           symptons as Symptons,
                           date_symptons as DateSymptons,
                           continuos_medicine as ContinuosMedicine,
                           allergies as Allergies,
                           emergency_id as EmergencyId
                      FROM screenings ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<ScreeningDto>(command);
    }

    public async Task<Screening?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           symptons as Symptons,
                           date_symptons as DateSymptons,
                           continuos_medicine as ContinuosMedicine,
                           allergies as Allergies,
                           emergency_id as EmergencyId
                      from screenings
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Screening>(command);
    }

    public async Task<ScreeningDto?> GetDataOfScreeningByEmergencyIdQuery(long emergencyId, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           symptons as Symptons,
                           date_symptons as DateSymptons,
                           continuos_medicine as ContinuosMedicine,
                           allergies as Allergies,
                           emergency_id as EmergencyId
                      from screenings
                     where emergency_id = @emergencyId";

        var command = new CommandDefinition(sql, new { emergencyId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<ScreeningDto>(command);
    }
}
