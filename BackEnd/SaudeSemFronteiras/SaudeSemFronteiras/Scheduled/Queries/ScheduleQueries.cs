using Dapper;
using SaudeSemFronteiras.Application.Scheduled.Domain;
using SaudeSemFronteiras.Application.Scheduled.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Scheduled.Queries;

public class ScheduleQueries(IDatabaseFactory databaseFactory) : IScheduleQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<ScheduleDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           value as Value,
                           scheduled_date as ScheduledDate,
                           is_active as IsActive,
                           appointment_id as AppointmentId
                      FROM sheduled ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<ScheduleDto>(command);
    }

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
}
