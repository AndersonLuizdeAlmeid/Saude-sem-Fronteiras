using SaudeSemFronteiras.Application.Invoices.Domain;
using SaudeSemFronteiras.Application.Invoices.Dtos;

namespace SaudeSemFronteiras.Application.Invoices.Queries;

public interface IInvoiceQueries
{
    Task<IEnumerable<InvoiceDto>> GetAll(CancellationToken cancellationToken);
    Task<Invoice?> GetByID(long iD, CancellationToken cancellationToken);
}
