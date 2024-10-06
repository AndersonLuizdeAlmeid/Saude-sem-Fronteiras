using Dapper;
using SaudeSemFronteiras.Application.Appointments.Dtos;
using SaudeSemFronteiras.Application.Emergencys.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Emergencys.Queries;
public class EmergencyQueries(IDatabaseFactory databaseFactory) : IEmergencyQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<EmergencyDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           price as Price,
                           wait_time as WaitTime,
                           status as Status,
                           appointment_id as AppointmentId
                      FROM emergencies ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<EmergencyDto>(command);
    }

    public async Task<EmergencyDto?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           price as Price,
                           wait_time as WaitTime,
                           status as Status,
                           appointment_id as AppointmentId
                      from emergencies
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<EmergencyDto>(command);
    }

    public async Task<IEnumerable<EmergencyShowDto?>> GetEmergenciesByPatientId(long patientId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT emergencies.id as Id, 
                           emergencies.price as Price,
                           emergencies.status as Status,
                           TO_CHAR(appointments.date, 'YYYY-MM-DD HH24:MI:SS') as Date
                      FROM emergencies INNER JOIN appointments 
                                               ON emergencies.appointment_id = appointments.id
                     WHERE appointments.patient_id = @patientId
                     ORDER BY Date DESC ";

        var command = new CommandDefinition(sql, new { patientId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<EmergencyShowDto>(command);
    }

    public async Task<long> GetLastEmergencyByPatientQuery(long patient_id, CancellationToken cancellationToken)
    {
        var sql = @"SELECT MAX(emergencies.id)
                      FROM emergencies INNER JOIN appointments
                                               ON emergencies.appointment_id = appointments.id
                     WHERE patient_id = @patient_id ";

        var command = new CommandDefinition(sql, new { patient_id }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken); return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<long>(command);
    }

    public async Task<IEnumerable<EmergencyShowDto?>> GetEmergenciesByDoctorIdQuery(long doctorId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT emergencies.id as Id, 
                           emergencies.price as Price,
                           emergencies.status as Status,
                           TO_CHAR(appointments.date, 'YYYY-MM-DD HH24:MI:SS') as Date,
                           appointments.doctor_id as DoctorId
                      FROM emergencies INNER JOIN appointments 
                                               ON emergencies.appointment_id = appointments.id
                     WHERE appointments.doctor_id = @doctorId
                     UNION ALL
                    SELECT emergencies.id as Id, 
                           emergencies.price as Price,
                           emergencies.status as Status,
  	                       TO_CHAR(appointments.date, 'YYYY-MM-DD HH24:MI:SS') as Date,
                           0 as DoctorId
                      FROM emergencies INNER JOIN appointments 
                                              ON emergencies.appointment_id = appointments.id
                     WHERE appointments.doctor_id = 0
                       AND emergencies.status = 1
                     ORDER BY Date "
        ;

        var command = new CommandDefinition(sql, new { doctorId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<EmergencyShowDto>(command);
    }

    public Task<string> GetPhoneByPatientQuery(long emergencyId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT users.phone
                      FROM users INNER JOIN patients
                                         ON patients.user_id = users.id
                                 INNER JOIN appointments 
                          		         ON appointments.patient_id = patients.id
                                 INNER JOIN emergencies
                          		 		 ON emergencies.appointment_id = appointments.id
                     WHERE emergencies.id = @emergencyId";

        var command = new CommandDefinition(sql, new { emergencyId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return LocalDatabase.Connection.QueryFirstAsync<string>(command);
    }

    public Task<AppointmentDto?> GetAppointmentByEmergencyIdQuery(long emergencyId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           date as Date,
                           duration as Duration,
                           doctor_id as DoctorId,
                           patient_id as PatientId
                      FROM emergencies INNER JOIN appointments
                                               ON emergencies.appointment_id = appointments.id
                     WHERE emergencies.id = @emergencyId";

        var command = new CommandDefinition(sql, new { emergencyId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return LocalDatabase.Connection.QueryFirstAsync<AppointmentDto?>(command);
    }
}
