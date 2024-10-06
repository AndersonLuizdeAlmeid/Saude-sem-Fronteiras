using Dapper;
using SaudeSemFronteiras.Application.Invoices.Domain;
using SaudeSemFronteiras.Application.Invoices.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Invoices.Queries;

public class InvoiceQueries(IDatabaseFactory databaseFactory) : IInvoiceQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<InvoiceDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           issuance_date as IssuanceDate,
                           due_date as DueDate, 
                           description as Description,   
                           status as Status,
                           value as Value,
                           tax as Tax,
                           discount as Discount,
                           terms as Terms,
                           appointment_id as AppointmentId
                      FROM invoices ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<InvoiceDto>(command);
    }

    public async Task<Invoice?> GetByID(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           issuance_date as IssuanceDate,
                           due_date as DueDate, 
                           description as Description,   
                           status as Status,
                           value as Value,
                           tax as Tax,
                           discount as Discount,
                           terms as Terms,
                           appointment_id as AppointmentId
                      from invoices
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Invoice>(command);
    }
}
