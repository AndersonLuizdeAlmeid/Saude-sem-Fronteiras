using Dapper;
using SaudeSemFronteiras.Application.Appointments.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Appointments.Repository;
public class AppointmentRepository(IDatabaseFactory LocalDatabase) : IAppointmentRepository
{
    public async Task Insert(Appointment appointment, CancellationToken cancellationToken)
    {
        var sql = @"insert into appointments(date, duration, doctor_id, patient_id) 
                    values (@Date, @Duration, @DoctorId, @PatientId)";

        var command = new CommandDefinition(sql, appointment, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Appointment appointment, CancellationToken cancellationToken)
    {
        var sql = @"update appointments
                       set date = @Date,
                           duration = @Duration
                           doctor_id = @DoctorId
                           patient_id = @PatientId
                     where id = @Id";

        var command = new CommandDefinition(sql, appointment, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Delete(long iD, CancellationToken cancellationToken)
    {
        var sql = @"delete from appointments
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
