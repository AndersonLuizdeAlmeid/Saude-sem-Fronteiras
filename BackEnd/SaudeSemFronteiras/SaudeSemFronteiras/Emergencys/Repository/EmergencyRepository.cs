using Dapper;
using SaudeSemFronteiras.Application.Emergencys.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Emergencys.Repository;
public class EmergencyRepository(IDatabaseFactory LocalDatabase) : IEmergencyRepository
{
    public async Task<Emergency?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           value as Value,
                           wait_time as WaitTime,
                           is_active as IsActive,
                           appointment_id as AppointmentId
                      from emergencys
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Emergency>(command);
    }

    public async Task Insert(Emergency emergency, CancellationToken cancellationToken)
    {
        var sql = @"insert into emergencys(value, wait_time, is_active, appointment_id) 
                                 values (@Value, @WaitTime, @IsActive, @AppointmentId)";
        var command = new CommandDefinition(sql, emergency, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Emergency emergency, CancellationToken cancellationToken)
    {
        var sql = @"update emergencys
                       set value = @Value, 
                           wait_time = @WaitTime,
                           is_active = @IsActive,
                           appointment_id = @AppointmentId
                     where id = @Id";

        var command = new CommandDefinition(sql, emergency, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
