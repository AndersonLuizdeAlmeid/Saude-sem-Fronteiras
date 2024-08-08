using Dapper;
using SaudeSemFronteiras.Application.Documents.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Documents.Repository;
public class DocumentRepository(IDatabaseFactory LocalDatabase) : IDocumentRepository
{
    public async Task Insert(Document document, CancellationToken cancellationToken)
    {
        var sql = @"insert into documents(description, type_document, date_document, digitally_signed, appointment_id) 
                                 values (@Description, @TypeDocument, @DateDocument, @DigitallySigned, @AppointmentId)";
        var command = new CommandDefinition(sql, document, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Document document, CancellationToken cancellationToken)
    {
        var sql = @"update documents
                       set description = @Description,
                           type_document = @TypeDocument
                           date_document = @DateDocument,
                           digitally_signed = @DigitallySigned,
                           appointment_id = @AppointmentId
                     where id = @Id";

        var command = new CommandDefinition(sql, document, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
