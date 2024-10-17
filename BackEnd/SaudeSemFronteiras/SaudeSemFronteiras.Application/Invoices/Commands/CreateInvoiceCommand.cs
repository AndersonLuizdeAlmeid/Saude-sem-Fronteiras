using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Invoices.Commands;
public class CreateInvoiceCommand : IRequest<Result>
{
    public DateTime DueDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Agency { get; set; } = string.Empty;
    public string Account { get; set; } = string.Empty;
    public string Digit { get; set; } = string.Empty;
    public long PatientId { get; set; }
    public long DoctorId { get; set; }
    public long AppointmentId { get; set; }

    public Result Validation()
    {
        if (DueDate.ToString().IsNullOrEmpty())
            return Result.Failure("Data de vencimento da fatura não pode ser nula.");
        if (DoctorId.ToString().IsNullOrEmpty())
            return Result.Failure("Médico não pode ser nulo.");
        if (PatientId.ToString().IsNullOrEmpty())
            return Result.Failure("Paciente não pode ser nulo.");
        if (AppointmentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta não pode ser nulo.");

        return Result.Success();
    }
}
