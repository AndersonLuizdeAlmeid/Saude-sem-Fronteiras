using Dapper;
using SaudeSemFronteiras.Application.Prescriptions.Domain;
using SaudeSemFronteiras.Application.Prescriptions.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Prescriptions.Queries;
public class PrescriptionQueries(IDatabaseFactory databaseFactory) : IPrescriptionQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<PrescriptionDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           issuance_date as IssuanceDate, 
                           title as Title, 
                           description as Description,
                           final_date as FinalDate,
                           observations as Observations,
                           prescritpion_validate as PrescriptionValidate,
                           document_id as DocumentId
                      FROM prescriptions ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<PrescriptionDto>(command);
    }

    public async Task<Prescription?> GetByID(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           issuance_date as IssuanceDate, 
                           title as Title, 
                           description as Description,
                           final_date as FinalDate,
                           observations as Observations,
                           prescritpion_validate as PrescriptionValidate,
                           document_id as DocumentId
                      from prescriptions
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Prescription>(command);
    }
}
