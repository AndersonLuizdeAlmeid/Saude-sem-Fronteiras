using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Chats.Commands;
public class ChangeChatCommand : IRequest<Result>
{
    public long Id { get; set; }
    public DateTime ChatDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public long AppointmentId { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código do chat não pode ser nulo.");
        if (ChatDate.ToString().IsNullOrEmpty())
            return Result.Failure("Data do chat não pode ser nula.");
        if (Status.IsNullOrEmpty())
            return Result.Failure("Status do chat não pode ser nulo.");
        if (AppointmentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta não pode ser nulo.");

        return Result.Success();
    }
}
