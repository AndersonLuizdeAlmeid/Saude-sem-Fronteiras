using Dapper;
using SaudeSemFronteiras.Application.Scheduled.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Scheduled.Repository;
public class ScheduleRepository(IDatabaseFactory LocalDatabase) : IScheduleRepository
{
    public async Task Insert(Schedule schedule, CancellationToken cancellationToken)
    {
        var sql = @"insert into scheduled(price, scheduled_date, status, appointment_id) 
                                 values (@Price, @ScheduledDate, @Status, @AppointmentId)";
        var command = new CommandDefinition(sql, schedule, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Schedule schedule, CancellationToken cancellationToken)
    {
        var sql = @"update scheduled
                       set price = @Price,
                           scheduled_date = @ScheduledDate,
                           status = @Status
                     where id = @Id";

        var command = new CommandDefinition(sql, schedule, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
