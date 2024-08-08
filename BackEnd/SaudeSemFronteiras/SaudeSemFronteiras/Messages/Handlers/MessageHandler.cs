using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Messages.Commands;
using SaudeSemFronteiras.Application.Messages.Domain;
using SaudeSemFronteiras.Application.Messages.Queries;
using SaudeSemFronteiras.Application.Messages.Repository;

namespace SaudeSemFronteiras.Application.Messages.Handlers;
public class MessageHandler : IRequestHandler<CreateMessageCommand, Result>,
                              IRequestHandler<ChangeMessageCommand, Result>
{
    private readonly IMessageRepository _messageRepository;
    private readonly IMessageQueries _messageQueries;

    public MessageHandler(IMessageRepository messageRepository, IMessageQueries messageQueries)
    {
        _messageRepository = messageRepository;
        _messageQueries = messageQueries;
    }

    public async Task<Result> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var message = Message.Create(request.MessageDate, request.Description, request.ChatId);

        await _messageRepository.Insert(message, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Handle(ChangeMessageCommand request, CancellationToken cancellationToken)
    {
        var message = await _messageQueries.GetById(request.Id, cancellationToken);
        if (message == null)
            return Result.Failure("Mensagem não encontrada");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        message.Update(request.MessageDate, request.Description, request.ChatId);

        await _messageRepository.Update(message, cancellationToken);

        return Result.Success();
    }
}
