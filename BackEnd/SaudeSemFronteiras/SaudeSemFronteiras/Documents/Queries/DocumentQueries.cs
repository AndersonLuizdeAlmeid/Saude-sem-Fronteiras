using Dapper;
using SaudeSemFronteiras.Application.Documents.Domain;
using SaudeSemFronteiras.Application.Documents.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Documents.Queries;
public class DocumentQueries(IDatabaseFactory databaseFactory) : IDocumentQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<DocumentDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           description as Description,
                           type_document as TypeDocument,
                           date_document as DateDocument,
                           digitally_signed as DigitallySigned,
                           appointment_id as AppointmentId
                      FROM documents ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<DocumentDto>(command);
    }

    public async Task<Document?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           description as Description,
                           type_document as TypeDocument,
                           date_document as DateDocument,
                           digitally_signed as DigitallySigned,
                           appointment_id as AppointmentId
                      from documents
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Document>(command);
    }
}
