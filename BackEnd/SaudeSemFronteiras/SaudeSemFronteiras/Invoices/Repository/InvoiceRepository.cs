using Dapper;
using SaudeSemFronteiras.Application.Invoices.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Invoices.Repository;
public class InvoiceRepository(IDatabaseFactory LocalDatabase) : IInvoiceRepository
{
    public async Task Insert(Invoice invoice, CancellationToken cancellationToken)
    {
        var sql = @"insert into invoices(issuance_date, due_date, description, status, value, tax, discount, terms, appointment_id) 
                    values (@IssuanceDate, @DueDate, @Description, @Status, @Value, @Tax, @Discount, @Terms, @AppointmentId)";

        var command = new CommandDefinition(sql, invoice, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Invoice invoice, CancellationToken cancellationToken)
    {
        var sql = @"update invoices
                       set issuance_date as IssuanceDate,
                           due_date as DueDate, 
                           description as Description,   
                           status as Status,
                           value as Value,
                           tax as Tax,
                           discount as Discount,
                           terms as Terms,
                           appointment_id as AppointmentId
                     where id = @Id";

        var command = new CommandDefinition(sql, invoice, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
