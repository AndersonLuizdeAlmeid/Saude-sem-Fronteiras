using Dapper;
using SaudeSemFronteiras.Application.Appointments.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Appointments.Repository;
public class AppointmentRepository(IDatabaseFactory LocalDatabase) : IAppointmentRepository
{
    public async Task Insert(Appointment appointment, CancellationToken cancellationToken)
    {
        var sql = @"insert into appointments(time, duration) 
                    values (@Time, @Duration)";

        var command = new CommandDefinition(sql, appointment, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Appointment appointment, CancellationToken cancellationToken)
    {
        var sql = @"update appointments
                       set time = @Time,
                           duration = @Duration
                     where id = @Id";

        var command = new CommandDefinition(sql, appointment, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
