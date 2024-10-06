using Dapper;
using SaudeSemFronteiras.Application.Medicines.Domain;
using SaudeSemFronteiras.Application.Medicines.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Medicines.Queries;
public class MedicineQueries(IDatabaseFactory databaseFactory) : IMedicineQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<MedicineDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id,
                           description as Description,
                           quantity as Quantity,
                           dosage as Dosage,
                           observation as Observation,
                           prescription as Prescription
                      FROM medicines ";

    var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<MedicineDto>(command);
    }

    public async Task<Medicine?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id,
                           description as Description,
                           quantity as Quantity,
                           dosage as Dosage,
                           observation as Observation,
                           prescription as Prescription
                      from medicines
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Medicine>(command);
    }
}
