using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Documents.Commands;
public class CreateDocumentCommand : IRequest<Result>
{
    public short TypeDocument { get; set; }
    public DateTime DateDocument { get; set; }
    public long AppointmentId { get; set; }

    public Result Validation()
    {
        if (TypeDocument.ToString().IsNullOrEmpty())
            return Result.Failure("Tipo de documento não pode ser nulo.");
        if (DateDocument.ToString().IsNullOrEmpty())
            return Result.Failure("Data do documento não pode ser nulo.");
        if (AppointmentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta não pode ser nulo.");

        return Result.Success();
    }
}
