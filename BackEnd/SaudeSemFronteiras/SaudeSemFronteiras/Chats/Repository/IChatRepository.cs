using SaudeSemFronteiras.Application.Chats.Domain;

namespace SaudeSemFronteiras.Application.Chats.Repository;
public interface IChatRepository
{
    Task<Chat?> GetById(long iD, CancellationToken cancellationToken);
    Task Insert(Chat chat, CancellationToken cancellationToken);
    Task Update(Chat chat, CancellationToken cancellationToken);
}
