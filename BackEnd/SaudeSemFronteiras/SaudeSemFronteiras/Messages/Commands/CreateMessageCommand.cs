using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Messages.Commands;
public class CreateMessageCommand : IRequest<Result>
{
    public DateTime MessageDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public long ChatId { get; set; }

    public Result Validation()
    {
        if (MessageDate.ToString().IsNullOrEmpty())
            return Result.Failure("Data da mensagem não pode ser nula.");
        if (Description.IsNullOrEmpty())
            return Result.Failure("Descrição da mensagem não pode ser nula.");
        if (ChatId.ToString().IsNullOrEmpty())
            return Result.Failure("Código do chat não pode ser nulo.");

        return Result.Success();
    }
}
