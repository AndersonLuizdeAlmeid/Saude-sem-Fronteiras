using SaudeSemFronteiras.Application.Chat.Domain;

namespace SaudeSemFronteiras.Application.Chat.Repository;
public interface IChatRepository
{
    Task<Chat?> GetById(long iD, CancellationToken cancellationToken);
    Task Insert(Chat chat, CancellationToken cancellationToken);
    Task Update(Chat chat, CancellationToken cancellationToken);
}
