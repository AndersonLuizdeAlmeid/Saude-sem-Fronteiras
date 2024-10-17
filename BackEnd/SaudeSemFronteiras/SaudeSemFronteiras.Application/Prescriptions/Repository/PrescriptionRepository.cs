using Dapper;
using SaudeSemFronteiras.Application.Prescriptions.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Prescriptions.Repository;
public class PrescriptionRepository(IDatabaseFactory LocalDatabase) : IPrescriptionRepository
{
    public async Task Insert(Prescription prescription, CancellationToken cancellationToken)
    {
        var sql = @"insert into prescriptions(description, document_id) 
                    values (@Description, @DocumentId)";

        var command = new CommandDefinition(sql, prescription, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Prescription prescription, CancellationToken cancellationToken)
    {
        var sql = @"update prescriptions
                       set description = @Description,
                           document_id = @DocumentId
                     where id = @Id";

        var command = new CommandDefinition(sql, prescription, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Delete(long iD, CancellationToken cancellationToken)
    {
        var sql = @"delete from prescriptions
                     where prescriptions.document_id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
