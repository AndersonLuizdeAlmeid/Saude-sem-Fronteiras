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
                           type_document as TypeDocument,
                           date_document as DateDocument,
                           appointment_id as AppointmentId
                      FROM documents ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<DocumentDto>(command);
    }

    public async Task<Document?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           type_document as TypeDocument,
                           date_document as DateDocument,
                           appointment_id as AppointmentId
                      from documents
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Document>(command);
    }

    public async Task<long?> GetLastDocumentIdByAppointmentIdQuery(long appointmentId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT MAX(id) as Id
                      FROM documents
                     WHERE appointment_id = @appointmentId";

        var command = new CommandDefinition(sql, new { appointmentId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<long>(command);
    }

    public async Task<IEnumerable<DocumentShowDto?>> GetDocumentsByDoctorIdQuery(long doctorId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT documents.id as Id,
                           users.name as Name, 
                           documents.type_document as Type, 
                           TO_CHAR(documents.date_document, 'YYYY-MM-DD HH24:MI:SS') as Date
                      FROM documents INNER JOIN appointments 
 					 	                     ON documents.appointment_id  = appointments.id
 				                     INNER JOIN patients 
 					 	                     ON patients.id = appointments.patient_id 
 				                     INNER JOIN users
 					 	                     ON users.id = patients.user_id
                     WHERE appointments.doctor_id = @doctorId ";

        var command = new CommandDefinition(sql, new { doctorId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<DocumentShowDto>(command);
    }

    public async Task<IEnumerable<DocumentShowDto?>> GetDocumentsByPatientIdQuery(long patientId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT documents.id as Id,
                           users.name as Name, 
                           documents.type_document as Type, 
                           TO_CHAR(documents.date_document, 'YYYY-MM-DD HH24:MI:SS') as Date
                      FROM documents INNER JOIN appointments 
 					 	                     ON documents.appointment_id  = appointments.id
 				                     INNER JOIN patients 
 					 	                     ON patients.id = appointments.patient_id 
 				                     INNER JOIN users
 					 	                     ON users.id = patients.user_id
                     WHERE appointments.patient_id = @patientId ";

        var command = new CommandDefinition(sql, new { patientId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<DocumentShowDto>(command);
    }
}
