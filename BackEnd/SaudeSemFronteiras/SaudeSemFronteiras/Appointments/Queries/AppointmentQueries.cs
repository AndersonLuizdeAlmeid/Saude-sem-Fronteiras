using Dapper;
using SaudeSemFronteiras.Application.Appointments.Domain;
using SaudeSemFronteiras.Application.Appointments.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Appointments.Queries;

public class AppointmentQueries(IDatabaseFactory databaseFactory) : IAppointmentQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<AppointmentDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           date as Date,
                           duration as Duration
                           doctor_id as DoctorId
                           patient_id as PatientId
                      FROM appointments ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<AppointmentDto>(command);
    }

    public async Task<Appointment?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           date as Date,
                           duration as Duration
                           doctor_id as DoctorId
                           patient_id as PatientId
                      from appointments
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Appointment>(command);
    }

    public async Task<int> GetAppointmentByDate(DateTime date, CancellationToken cancellationToken)
    {
        var sql = @"SELECT COUNT(id)
                      FROM appointments
                     WHERE date = @date";

        var command = new CommandDefinition(sql, new { date }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<int>(command);
    }

    public async Task<IEnumerable<AppointmentDto?>> GetAllFreeTimeByDoctor(long doctor_id, DateOnly date,CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           date as Date,
                           duration as Duration,
                           doctor_id as DoctorId,
                           patient_id as PatientId
                      FROM appointments
                     WHERE doctor_id = @doctor_id
                       AND date::DATE = @date";

        var dateAsDateTime = date.ToDateTime(TimeOnly.MinValue);

        var command = new CommandDefinition(sql, new { doctor_id, date = dateAsDateTime }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<AppointmentDto>(command);
    }

    public async Task<IEnumerable<AppointmentShowDto?>> GetAppointmentsByPatientId(long patientId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           date as Date
                      FROM appointments
                     WHERE patient_id = @patientId";

        var command = new CommandDefinition(sql, new { patientId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<AppointmentShowDto>(command);
    }
}
