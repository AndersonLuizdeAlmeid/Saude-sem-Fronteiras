using Dapper;
using SaudeSemFronteiras.Application.Screenings.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Screenings.Repository;
public class ScreeningRepository(IDatabaseFactory LocalDatabase) : IScreeningRepository
{
    public async Task Insert(Screening screening, CancellationToken cancellationToken)
    {
        var sql = @"insert into screenings(symptons, date_symptons, continuos_medicine, allergies, observations, emergency_id) 
                                   values (@Symptons, @DateSymptons, @ContinuosMedicine, @Allergies, @Observations, @EmergencyId)";
        var command = new CommandDefinition(sql, screening, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Screening screening, CancellationToken cancellationToken)
    {
        var sql = @"update screenings
                       set symptons = @Symptons,
                           date_symptons = @DateSymptons,
                           continuos_medicine = @ContinuosMedicine,
                           allergies = @Allergies,
                           observations = @Observations,
                           emergency_id = @EmergencyId
                     where id = @Id";

        var command = new CommandDefinition(sql, screening, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
