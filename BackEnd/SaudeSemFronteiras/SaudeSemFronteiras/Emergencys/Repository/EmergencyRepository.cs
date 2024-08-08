using Dapper;
using SaudeSemFronteiras.Application.Emergencys.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Emergencys.Repository;
public class EmergencyRepository(IDatabaseFactory LocalDatabase) : IEmergencyRepository
{
    public async Task Insert(Emergency emergency, CancellationToken cancellationToken)
    {
        var sql = @"insert into emergencies(value, wait_time, is_active, appointment_id) 
                                 values (@Value, @WaitTime, @IsActive, @AppointmentId)";
        var command = new CommandDefinition(sql, emergency, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Emergency emergency, CancellationToken cancellationToken)
    {
        var sql = @"update emergencies
                       set value = @Value, 
                           wait_time = @WaitTime,
                           is_active = @IsActive,
                           appointment_id = @AppointmentId
                     where id = @Id";

        var command = new CommandDefinition(sql, emergency, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
