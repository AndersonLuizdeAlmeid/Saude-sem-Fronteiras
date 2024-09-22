using Dapper;
using SaudeSemFronteiras.Application.Emergencys.Domain;
using SaudeSemFronteiras.Application.Emergencys.Dtos;
using SaudeSemFronteiras.Application.Scheduled.Dtos;
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
}
