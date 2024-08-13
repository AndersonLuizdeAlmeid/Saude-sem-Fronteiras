using Dapper;
using SaudeSemFronteiras.Application.Doctors.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Doctors.Repository;
public class DoctorRepository(IDatabaseFactory LocalDatabase) : IDoctorRepository
{
    public async Task Insert(Doctor doctor, CancellationToken cancellationToken)
    {
        var sql = @"insert into doctors(registry_number, avaibality_hours, consultation_price, user_id) 
                    values (@RegistryNumber, @AvaibalityHours, @ConsultationPrince, @UserId)";

        var command = new CommandDefinition(sql, doctor, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Doctor doctor, CancellationToken cancellationToken)
    {
        var sql = @"update doctors
                       set registry_number = @RegistryNumber, 
                           avaibality_hours = @AvaibalityHours, 
                           consultation_price = @ConsultationPrince,
                           user_id = @UserId
                     where id = @Id";

        var command = new CommandDefinition(sql, doctor, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
