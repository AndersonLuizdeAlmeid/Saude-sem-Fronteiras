using Dapper;
using SaudeSemFronteiras.Application.Scheduled.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Scheduled.Repository;
public class ScheduleRepository(IDatabaseFactory LocalDatabase) : IScheduleRepository
{
    public async Task<Schedule?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           value as Value,
                           scheduled_date as ScheduledDate,
                           is_active as IsActive,
                           appointment_id as AppointmentId
                      from scheduled
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Schedule>(command);
    }

    public async Task Insert(Schedule schedule, CancellationToken cancellationToken)
    {
        var sql = @"insert into scheduled(value, scheduled_date, is_active, appointment_id) 
                                 values (@Value, @ScheduledDate, @IsActive, @AppointmentId)";
        var command = new CommandDefinition(sql, schedule, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Schedule schedule, CancellationToken cancellationToken)
    {
        var sql = @"update scheduled
                       set value = @Value, 
                           scheduled_date = @ScheduledDate,
                           is_active = @IsActive,
                           appointment_id = @AppointmentId
                     where id = @Id";

        var command = new CommandDefinition(sql, schedule, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
