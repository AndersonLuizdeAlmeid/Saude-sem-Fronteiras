using Dapper;
using SaudeSemFronteiras.Application.Scheduled.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Scheduled.Repository;
public class ScheduleRepository(IDatabaseFactory LocalDatabase) : IScheduleRepository
{
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
