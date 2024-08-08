using Dapper;
using SaudeSemFronteiras.Application.Certificates.Domain;
using SaudeSemFronteiras.Application.Certificates.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Certificates.Queries;

public class CertifiecateQueries(IDatabaseFactory databaseFactory) : ICertificateQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<CertificateDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           issuance_date as IssuanceDate, 
                           title as Title, 
                           description as Description,
                           start_date as StartDate,
                           final_date as FinalDate,
                           observations as Observations,
                           document_id as DocumentId
                      FROM certificates ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<CertificateDto>(command);
    }

    public async Task<Certificate?> GetByID(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           issuance_date as IssuanceDate, 
                           title as Title, 
                           description as Description,
                           start_date as StartDate,
                           final_date as FinalDate,
                           observations as Observations,
                           document_id as DocumentId
                      from certificates
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Certificate>(command);
    }
}
