using SaudeSemFronteiras.Application.Documents.Domain;
using SaudeSemFronteiras.Application.Documents.Dtos;
using SaudeSemFronteiras.Application.Invoices.Dtos;

namespace SaudeSemFronteiras.Application.Documents.Queries;
public interface IDocumentQueries
{
    Task<IEnumerable<DocumentDto>> GetAll(CancellationToken cancellationToken);
    Task<Document?> GetById(long iD, CancellationToken cancellationToken);
    Task<long?> GetLastDocumentIdByAppointmentIdQuery(long appointmentId, CancellationToken cancellationToken);
    Task<IEnumerable<DocumentShowDto?>> GetDocumentsByDoctorIdQuery(long doctorId, CancellationToken cancellationToken);
    Task<IEnumerable<DocumentShowDto?>> GetDocumentsByPatientIdQuery(long patientId, CancellationToken cancellationToken);
    Task<IEnumerable<DocumentShowDto?>> GetPatientsDocumentsByDoctorQuery(long doctorId, long patientId, CancellationToken cancellationToken);

}
