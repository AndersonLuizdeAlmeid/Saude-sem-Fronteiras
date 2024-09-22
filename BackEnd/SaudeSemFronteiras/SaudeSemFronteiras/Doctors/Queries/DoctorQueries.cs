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
                           initial_hour as InitialHour,
                           final_hour as FinalHour,
                           consultation_price as ConsultationPrice,
                           days as Days,
                           user_id as UserId
                      FROM doctors ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<DoctorDto>(command);
    }

    public async Task<Doctor?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           registry_number as RegistryNumber, 
                           initial_hour as InitialHour,
                           final_hour as FinalHour,
                           consultation_price as ConsultationPrice,
                           days as Days,
                           user_id as UserId
                      from doctors
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Doctor>(command);
    }

    public async Task<DoctorDto?> GetDtoById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           registry_number as RegistryNumber, 
                           initial_hour as InitialHour,
                           final_hour as FinalHour,
                           consultation_price as ConsultationPrice,
                           days as Days,
                           user_id as UserId
                      from doctors
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<DoctorDto>(command);
    }

    public async Task<DoctorDto?> GetByUserId(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           registry_number as RegistryNumber, 
                           initial_hour as InitialHour,
                           final_hour as FinalHour,
                           consultation_price as ConsultationPrice,
                           days as Days,
                           user_id as UserId
                      from doctors
                     where user_id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<DoctorDto>(command);
    }

    public async Task<IEnumerable<DoctorComboboxDto>> GetAllDoctorsBySpeciality(long specialityId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT doctors.id AS Id,
                           users.name AS Name
                      FROM doctors
                           INNER JOIN users ON users.id = doctors.user_id
                           inner join specialities on doctors.id = specialities.doctor_id 
                     WHERE specialities.id = @specialityId";

        var command = new CommandDefinition(sql, new { specialityId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<DoctorComboboxDto>(command);
    }

    public async Task<decimal?> GetPriceByDoctorIdQuery(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select consultation_price as ConsultationPrice
                      from doctors
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<decimal>(command);
    }
}
