using Dapper;
using SaudeSemFronteiras.Application.Doctors.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Doctors.Repository;
public class DoctorRepository(IDatabaseFactory LocalDatabase) : IDoctorRepository
{
    public async Task<Doctor?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           registry_number as RegistryNumber, 
                           avaibality_hours as AvaibalityHours, 
                           consultation_price as ConsultationPrince,
                           user_id as IdUser,
                           appointment_id as IdAppointment
                      from doctors
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Doctor>(command);
    }
    public async Task Insert(Doctor doctor, CancellationToken cancellationToken)
    {
        var sql = @"insert into doctors(registry_number, avaibality_hours, consultation_price, user_id, appointment_id) 
                    values (@RegistryNumber, @AvaibalityHours, @ConsultationPrince, @IdUser, @IdAppointment)";

        var command = new CommandDefinition(sql, doctor, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Doctor doctor, CancellationToken cancellationToken)
    {
        var sql = @"update doctors
                       set registry_number = @RegistryNumber, 
                           avaibality_hours = @AvaibalityHours, 
                           consultation_price = @ConsultationPrince,
                           user_id = @IdUser,
                           appointment_id = @IdAppointment
                     where id = @Id";

        var command = new CommandDefinition(sql, doctor, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
