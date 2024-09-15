using Dapper;
using SaudeSemFronteiras.Application.Doctors.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Doctors.Repository;
public class DoctorRepository(IDatabaseFactory LocalDatabase) : IDoctorRepository
{
    public async Task Insert(Doctor doctor, CancellationToken cancellationToken)
    {
        var sql = @"insert into doctors(registry_number, initial_hour, final_hour, consultation_price, days, user_id) 
                    values (@RegistryNumber, @InitialHour, @FinalHour, @Days, @ConsultationPrice, @UserId)";

        var command = new CommandDefinition(sql, doctor, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Doctor doctor, CancellationToken cancellationToken)
    {
        var sql = @"update doctors
                       set registry_number = @RegistryNumber, 
                           initial_hour = @InitialHour,
                           final_hour = @FinalHour,
                           consultation_price = @ConsultationPrice,
                           days = @Days,
                           user_id = @UserId
                     where id = @Id";

        var command = new CommandDefinition(sql, doctor, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
