using Dapper;
using SaudeSemFronteiras.Application.Doctors.Domain;
using SaudeSemFronteiras.Application.Doctors.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Doctors.Queries;
public class DoctorQueries(IDatabaseFactory databaseFactory) : IDoctorQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<DoctorDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           registry_number as RegistryNumber, 
                           avaibality_hours as AvaibalityHours, 
                           consultation_price as ConsultationPrince,
                           user_id as IdUser
                      FROM doctors ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<DoctorDto>(command);
    }

    public async Task<Doctor?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           registry_number as RegistryNumber, 
                           avaibality_hours as AvaibalityHours, 
                           consultation_price as ConsultationPrince,
                           user_id as IdUser
                      from doctors
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Doctor>(command);
    }
}
