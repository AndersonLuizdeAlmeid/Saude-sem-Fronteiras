using Dapper;
using SaudeSemFronteiras.Application.Documents.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Documents.Repository;
public class DocumentRepository(IDatabaseFactory LocalDatabase) : IDocumentRepository
{
    public async Task Insert(Document document, CancellationToken cancellationToken)
    {
        var sql = @"insert into documents(type_document, date_document, appointment_id) 
                                 values (@TypeDocument, @DateDocument, @AppointmentId)";
        var command = new CommandDefinition(sql, document, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Document document, CancellationToken cancellationToken)
    {
        var sql = @"update documents
                       set type_document = @TypeDocument
                           date_document = @DateDocument,
                           appointment_id = @AppointmentId
                     where id = @Id";

        var command = new CommandDefinition(sql, document, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Delete(long iD, CancellationToken cancellationToken)
    {
        var sql = @"delete from documents
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
