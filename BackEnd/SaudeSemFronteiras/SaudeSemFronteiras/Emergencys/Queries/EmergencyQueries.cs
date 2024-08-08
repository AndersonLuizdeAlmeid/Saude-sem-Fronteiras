using Dapper;
using SaudeSemFronteiras.Application.Emergencys.Domain;
using SaudeSemFronteiras.Application.Emergencys.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Emergencys.Queries;
public class EmergencyQueries(IDatabaseFactory databaseFactory) : IEmergencyQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<EmergencyDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as ID,
                           name as Name,
                           cpf as CPF,
                           motherName as MotherName,
                           dateBirth as DateBirth,
                           language as Language,
                           is_active as IsActive
                      FROM emergencies ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<EmergencyDto>(command);
    }

    public async Task<Emergency?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           value as Value,
                           wait_time as WaitTime,
                           is_active as IsActive,
                           appointment_id as AppointmentId
                      from emergencies
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Emergency>(command);
    }
}
