using Dapper;
using SaudeSemFronteiras.Application.Scheduled.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Scheduled.Queries;

public class ScheduleQueries(IDatabaseFactory databaseFactory) : IScheduleQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<ScheduleDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id,
                           price as Price,
                           scheduled_date as ScheduledDate,
                           status as Status,
                           appointment_id as AppointmentId
                      FROM sheduled ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<ScheduleDto>(command);
    }

    public async Task<ScheduleDto?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           price as Price,
                           scheduled_date as ScheduledDate,
                           status as Status,
                           appointment_id as AppointmentId
                      from scheduled
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<ScheduleDto>(command);
    }

    public async Task<IEnumerable<ScheduleShowDto?>> GetAppointmentsByPatientId(long patientId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT scheduled.id as Id, 
                           scheduled.price as Price,
                           scheduled.status as Status,
                           TO_CHAR(scheduled_date, 'YYYY-MM-DD HH24:MI:SS') as Date
                      FROM scheduled INNER JOIN appointments 
                                             ON scheduled.appointment_id = appointments.id
                     WHERE appointments.patient_id = @patientId
                     ORDER BY Date DESC ";

        var command = new CommandDefinition(sql, new { patientId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<ScheduleShowDto>(command);
    }

    public async Task<IEnumerable<ScheduleShowDto?>> GetAppointmentsByDoctorId(long doctorId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT scheduled.id as Id, 
                           scheduled.price as Price,
                           scheduled.status as Status,
                           TO_CHAR(scheduled_date, 'YYYY-MM-DD HH24:MI:SS') as Date
                      FROM scheduled INNER JOIN appointments 
                                             ON scheduled.appointment_id = appointments.id
                     WHERE appointments.doctor_id = @doctorId
                     ORDER BY Date DESC "
        ;

        var command = new CommandDefinition(sql, new { doctorId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<ScheduleShowDto>(command);
    }

    public Task<string> GetPhoneByDoctorQuery(long scheduleId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT users.phone
                      FROM users INNER JOIN doctors
                                         ON doctors.user_id = users.id
                                 INNER JOIN appointments 
                          		         ON appointments.doctor_id = doctors.id
                                 INNER JOIN scheduled
                          		 		 ON scheduled.appointment_id = appointments.id
                     WHERE scheduled.id = @scheduleId";

        var command = new CommandDefinition(sql, new { scheduleId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return LocalDatabase.Connection.QueryFirstAsync<string>(command);
    }

    public Task<string> GetPhoneByPatientQuery(long scheduleId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT users.phone
                      FROM users INNER JOIN patients
                                         ON patients.user_id = users.id
                                 INNER JOIN appointments 
                          		         ON appointments.patient_id = patients.id
                                 INNER JOIN scheduled
                          		 		 ON scheduled.appointment_id = appointments.id
                     WHERE scheduled.id = @scheduleId";

        var command = new CommandDefinition(sql, new { scheduleId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return LocalDatabase.Connection.QueryFirstAsync<string>(command);
    }
}
