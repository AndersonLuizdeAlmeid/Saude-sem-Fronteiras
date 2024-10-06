using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Invoices.Commands;
public class ChangeInvoiceCommand : IRequest<Result>
{
    public long Id { get; set; }
    public DateTime IssuanceDate { get; set; }
    public DateTime DueDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string Tax { get; set; } = string.Empty;
    public string Discount { get; set; } = string.Empty;
    public string Terms { get; set; } = string.Empty;
    public long AppointmentId { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código do fatura não pode ser nulo.");
        if (IssuanceDate.ToString().IsNullOrEmpty())
            return Result.Failure("Data de emissão da fatura não pode ser nula.");
        if (DueDate.ToString().IsNullOrEmpty())
            return Result.Failure("Data de vencimento da fatura não pode ser nula.");
        if (Description.IsNullOrEmpty())
            return Result.Failure("Descrição da fatura não pode ser nula.");
        if (Status.IsNullOrEmpty())
            return Result.Failure("Status da fatura não pode ser nulo.");
        if (Value.IsNullOrEmpty())
            return Result.Failure("Valor da fatura não pode ser nulo.");
        if (AppointmentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta não pode ser nulo.");

        return Result.Success();
    }
}
