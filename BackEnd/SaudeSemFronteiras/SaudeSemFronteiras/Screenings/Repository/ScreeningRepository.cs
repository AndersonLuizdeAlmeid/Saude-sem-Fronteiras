using Dapper;
using SaudeSemFronteiras.Application.Screenings.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Screenings.Repository;
public class ScreeningRepository(IDatabaseFactory LocalDatabase) : IScreeningRepository
{
    public async Task<Screening?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           degree_severity as DegreeSeverity, 
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

    public async Task Insert(Screening screening, CancellationToken cancellationToken)
    {
        var sql = @"insert into screenings(degree_severity, symptons, date_symptons, continuos_medicine, allergies, emergency_id) 
                                   values (@DegreeSeverity, @Symptons, @DateSymptons, @ContinuosMedicine, @Allergies, @EmergencyId)";
        var command = new CommandDefinition(sql, screening, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Screening screening, CancellationToken cancellationToken)
    {
        var sql = @"update screenings
                       set degree_severity = @DegreeSeverity, 
                           symptons = @Symptons,
                           date_symptons = @DateSymptons,
                           continuos_medicine = @ContinuosMedicine,
                           allergies = @Allergies,
                           emergency_id = @EmergencyId
                     where id = @Id";

        var command = new CommandDefinition(sql, screening, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
