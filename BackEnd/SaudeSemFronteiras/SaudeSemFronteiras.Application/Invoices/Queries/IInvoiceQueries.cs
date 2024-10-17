using SaudeSemFronteiras.Application.Invoices.Dtos;

namespace SaudeSemFronteiras.Application.Invoices.Queries;

public interface IInvoiceQueries
{
    Task<IEnumerable<InvoiceDto>> GetAll(CancellationToken cancellationToken);
    Task<InvoiceDto?> GetByID(long iD, CancellationToken cancellationToken);
    Task<IEnumerable<InvoiceShowDto?>> GetInvoiceByDoctorIdQuery(long doctorId, CancellationToken cancellationToken);
    Task<IEnumerable<InvoiceShowDto?>> GetInvoiceByPatientQuery(long patientId, CancellationToken cancellationToken);
    Task<InvoiceCompleteDto?> GetDataToBoleto(long iD, CancellationToken cancellationToken);
}