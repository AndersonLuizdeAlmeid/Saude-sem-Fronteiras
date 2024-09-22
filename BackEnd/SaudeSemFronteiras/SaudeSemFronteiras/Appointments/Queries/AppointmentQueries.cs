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
                           duration as Duration,
                           doctor_id as DoctorId,
                           patient_id as PatientId
                      FROM appointments ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<AppointmentDto>(command);
    }

    public async Task<Appointment?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           date as Date,
                           duration as Duration,
                           doctor_id as DoctorId,
                           patient_id as PatientId
                      from appointments
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Appointment>(command);
    }
    public async Task<long?> GetPatientIdByAppointmentId(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select patient_id as PatientId
                      from appointments
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<long>(command);
    }

    public async Task<int> GetAppointmentByDate(DateTime date, CancellationToken cancellationToken)
    {
        var sql = @"SELECT COUNT(id)
                      FROM appointments
                     WHERE date = @date";

        var command = new CommandDefinition(sql, new { date }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<int>(command);
    }

    public async Task<IEnumerable<AppointmentDto?>> GetAllFreeTimeByDoctor(long doctor_id, DateOnly date, CancellationToken cancellationToken)
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
                           TO_CHAR(date, 'YYYY-MM-DD HH24:MI:SS') as Date
                      FROM appointments
                     WHERE patient_id = @patientId
                     ORDER BY Date ";

        var command = new CommandDefinition(sql, new { patientId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<AppointmentShowDto>(command);
    }

    public async Task<IEnumerable<AppointmentShowDto?>> GetAppointmentsByDoctorId(long doctorId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           TO_CHAR(date, 'YYYY-MM-DD HH24:MI:SS') as Date
                      FROM appointments
                     WHERE doctor_id = @doctorId
                     ORDER BY Date "
        ;

        var command = new CommandDefinition(sql, new { doctorId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<AppointmentShowDto>(command);
    }

    public Task<string> GetPhoneByPatient(long appointmentId, long patientId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT users.phone
                      FROM users INNER JOIN patients
                                         ON patients.user_id = users.id
                                 INNER JOIN appointments 
                          		         ON appointments.patient_id = patients.id
                     WHERE patients.id = @patientId
                       AND appointments.id = @appointmentId";

        var command = new CommandDefinition(sql, new { patientId, appointmentId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return LocalDatabase.Connection.QueryFirstAsync<string>(command);
    }

    public async Task<long> GetLastAppointmentByPatientAndDoctor(long doctor_id, long patient_id, CancellationToken cancellationToken)
    {
        var sql = @"SELECT MAX(id)
                      FROM appointments
                     WHERE doctor_id = @doctor_id
                       AND patient_id = @patient_id";

        var command = new CommandDefinition(sql, new { doctor_id, patient_id }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<long>(command);
    }

    public async Task<long> GetLastAppointmentByPatientQuery(long patient_id, CancellationToken cancellationToken)
    {
        var sql = @"SELECT MAX(id)
                      FROM appointments
                     WHERE patient_id = @patient_id ";

        var command = new CommandDefinition(sql, new { patient_id }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<long>(command);
    }

    public async Task<string> GetDateByEmergencyIdQuery(long emergencyId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT TO_CHAR(appointments.date, 'YYYY-MM-DD HH24:MI:SS') AS date_string
                      FROM appointments INNER JOIN emergencies
                                                ON appointments.id = emergencies.appointment_id
                     WHERE emergencies.id = @emergencyId ";

        var command = new CommandDefinition(sql, new { emergencyId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken); 
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<string>(command);
    }
}
