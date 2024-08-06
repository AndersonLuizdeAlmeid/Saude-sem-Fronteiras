using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Chats.Domain;
using SaudeSemFronteiras.Application.Chats.Commands;
using SaudeSemFronteiras.Application.Chats.Repository;

namespace SaudeSemFronteiras.Application.Chats.Handlers;
public class ChatHandler : IRequestHandler<CreateChatCommand, Result>,
                           IRequestHandler<ChangeChatCommand, Result>
{
    private readonly IChatRepository _chatRepository;

    public ChatHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<Result> Handle(CreateChatCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var chat = Chat.Create(request.ChatDate, request.Status, request.AppointmentId);

        await _chatRepository.Insert(chat, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Handle(ChangeChatCommand request, CancellationToken cancellationToken)
    {
        var chat = await _chatRepository.GetById(request.Id, cancellationToken);
        if (chat == null)
            return Result.Failure("Chat não encontrado");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        chat.Update(request.ChatDate, request.Status, request.AppointmentId);

        await _chatRepository.Update(chat, cancellationToken);

        return Result.Success();
    }
}
