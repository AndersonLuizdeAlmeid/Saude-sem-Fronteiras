using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Chats.Commands;
public class CreateChatCommand : IRequest<Result>
{
    public DateTime ChatDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public long AppointmentId { get; set; }

    public Result Validation()
    {
        if (ChatDate.ToString().IsNullOrEmpty())
            return Result.Failure("Data do chat não pode ser nula.");
        if (Status.IsNullOrEmpty())
            return Result.Failure("Status do chat não pode ser nulo.");
        if (AppointmentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código da consulta não pode ser nulo.");

        return Result.Success();
    }
}
