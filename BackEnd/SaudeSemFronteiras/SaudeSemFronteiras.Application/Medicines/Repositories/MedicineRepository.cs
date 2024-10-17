using Dapper;
using SaudeSemFronteiras.Application.Medicines.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Medicines.Repositories;
public class MedicineRepository(IDatabaseFactory LocalDatabase) : IMedicineRepository
{
    public async Task Insert(Medicine document, CancellationToken cancellationToken)
    {
        var sql = @"insert into medicines(description, quantity, dosage, observation, prescription_id) 
                             values (@Description, @Quantity, @Dosage, @Observation, @PrescriptionId)";

    var command = new CommandDefinition(sql, document, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Delete(long iD, CancellationToken cancellationToken)
    {
        var sql = @"delete from medicines
                     where prescription_id IN (
                         select prescriptions.id
                         from prescriptions
                         where prescriptions.document_id = @iD
                     )";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
