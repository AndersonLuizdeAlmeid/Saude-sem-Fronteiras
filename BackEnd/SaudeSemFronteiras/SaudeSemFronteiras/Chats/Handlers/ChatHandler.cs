using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Chats.Domain;
using SaudeSemFronteiras.Application.Chats.Commands;
using SaudeSemFronteiras.Application.Chats.Repository;
using SaudeSemFronteiras.Application.Chats.Queries;

namespace SaudeSemFronteiras.Application.Chats.Handlers;
public class ChatHandler : IRequestHandler<CreateChatCommand, Result>,
                           IRequestHandler<ChangeChatCommand, Result>
{
    private readonly IChatRepository _chatRepository;
    private readonly IChatQueries _chatQueries;

    public ChatHandler(IChatRepository chatRepository, IChatQueries chatQueries)
    {
        _chatRepository = chatRepository;
        _chatQueries = chatQueries;
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
        var chat = await _chatQueries.GetById(request.Id, cancellationToken);
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
