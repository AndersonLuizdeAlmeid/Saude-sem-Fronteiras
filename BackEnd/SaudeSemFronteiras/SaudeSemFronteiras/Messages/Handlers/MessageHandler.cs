using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Messages.Commands;
using SaudeSemFronteiras.Application.Messages.Domain;
using SaudeSemFronteiras.Application.Messages.Repository;

namespace SaudeSemFronteiras.Application.Messages.Handlers;
public class MessageHandler : IRequestHandler<CreateMessageCommand, Result>,
                              IRequestHandler<ChangeMessageCommand, Result>
{
    private readonly IMessageRepository _messageRepository;

    public MessageHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
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
        var message = await _messageRepository.GetById(request.Id, cancellationToken);
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
