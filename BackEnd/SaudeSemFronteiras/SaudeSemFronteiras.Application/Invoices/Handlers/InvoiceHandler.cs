using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Doctors.Queries;
using SaudeSemFronteiras.Application.Documents.Commands;
using SaudeSemFronteiras.Application.Invoices.Commands;
using SaudeSemFronteiras.Application.Invoices.Domain;
using SaudeSemFronteiras.Application.Invoices.Queries;
using SaudeSemFronteiras.Application.Invoices.Repository;

namespace SaudeSemFronteiras.Application.Invoices.Handlers;
public class InvoiceHandler : IRequestHandler<CreateInvoiceCommand, Result>,
                              IRequestHandler<ChangeInvoiceCommand, Result>,
                              IRequestHandler<DeleteInvoiceCommand, Result>
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IInvoiceQueries _invoiceQueries;
    private readonly IDoctorQueries _doctorQueries;

    public InvoiceHandler(IInvoiceRepository invoiceRepository, IInvoiceQueries invoiceQueries, IDoctorQueries doctorQueries)
    {
        _invoiceRepository = invoiceRepository;
        _invoiceQueries = invoiceQueries;
        _doctorQueries = doctorQueries;
    }

    public async Task<Result> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var priceAppointment = _doctorQueries.GetPriceByAppointmentQuery(request.AppointmentId, request.AppointmentId, cancellationToken);
        if (priceAppointment.Result == 0)
            return Result.Failure("Valor está zerado.");

        var invoice = Invoice.Create(request.DueDate, priceAppointment.Result, 1, request.Description, request.Agency, request.Account, request.Digit, "17", request.PatientId, request.DoctorId, request.AppointmentId);

        await _invoiceRepository.Insert(invoice, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(ChangeInvoiceCommand request, CancellationToken cancellationToken)
    {
        //TODO Ver possibilidade de bloquear quando tiver consultas abertas.
        var invoiceDto = await _invoiceQueries.GetByID(request.Id, cancellationToken);
        if (invoiceDto == null)
            return Result.Failure("Fatura não encontrada");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var invoice = new Invoice(request.Id, 
                                  invoiceDto.IssuanceDate,
                                  invoiceDto.DueDate,
                                  invoiceDto.Value,
                                  request.Status,
                                  invoiceDto.Description,
                                  invoiceDto.Agency,
                                  invoiceDto.Account,
                                  invoiceDto.Digit,
                                  invoiceDto.StandardWallet,
                                  invoiceDto.PatientId,
                                  invoiceDto.DoctorId,
                                  invoiceDto.AppointmentId);

        invoice.Update(invoiceDto.IssuanceDate, invoiceDto.DueDate, invoiceDto.Value, request.Status, invoiceDto.Description, invoiceDto.Agency, invoiceDto.Account, invoiceDto.Digit, invoiceDto.StandardWallet, invoiceDto.PatientId, invoiceDto.DoctorId, invoiceDto.AppointmentId);

        await _invoiceRepository.Update(invoice, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        await _invoiceRepository.Delete(request.Id, cancellationToken);

        return Result.Success();
    }
}
