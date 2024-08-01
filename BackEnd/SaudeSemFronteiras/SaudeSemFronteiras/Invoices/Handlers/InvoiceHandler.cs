using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Invoices.Commands;
using SaudeSemFronteiras.Application.Invoices.Domain;
using SaudeSemFronteiras.Application.Invoices.Repository;

namespace SaudeSemFronteiras.Application.Invoices.Handlers;
public class InvoiceHandler : IRequestHandler<CreateInvoiceCommand, Result>,
                              IRequestHandler<ChangeInvoiceCommand, Result>
{
    private readonly IInvoiceRepository _invoiceRepository;

    public InvoiceHandler(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public async Task<Result> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var invoice = Invoice.Create(request.DueDate, request.Description, request.Status, request.Value, request.Tax, request.Discount, request.Terms, request.AppointmentId);

        await _invoiceRepository.Insert(invoice, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(ChangeInvoiceCommand request, CancellationToken cancellationToken)
    {
        //TODO Ver possibilidade de bloquear quando tiver consultas abertas.
        var invoice = await _invoiceRepository.GetByID(request.Id, cancellationToken);
        if (invoice == null)
            return Result.Failure("Fatura não encontrada");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        invoice.Update(request.IssuanceDate, request.DueDate, request.Description, request.Status, request.Value, request.Tax, request.Discount, request.Terms, request.AppointmentId);

        await _invoiceRepository.Update(invoice, cancellationToken);

        return Result.Success();
    }


}
