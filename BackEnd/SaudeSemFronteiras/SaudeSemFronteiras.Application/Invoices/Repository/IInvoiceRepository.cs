using SaudeSemFronteiras.Application.Invoices.Domain;

namespace SaudeSemFronteiras.Application.Invoices.Repository;
public interface IInvoiceRepository
{
    Task Insert(Invoice invoice, CancellationToken cancellationToken);
    Task Update(Invoice invoice, CancellationToken cancellationToken);
    Task Delete(long iD, CancellationToken cancellationToken);
    Task UpdatePatientInvoices(long iD, CancellationToken cancellationToken);
    Task UpdateDoctorInvoices(long iD, CancellationToken cancellationToken);
}