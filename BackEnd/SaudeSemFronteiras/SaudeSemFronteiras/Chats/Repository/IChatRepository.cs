using SaudeSemFronteiras.Application.Chats.Domain;

namespace SaudeSemFronteiras.Application.Chats.Repository;
public interface IChatRepository
{
    Task Insert(Chat chat, CancellationToken cancellationToken);
    Task Update(Chat chat, CancellationToken cancellationToken);
}
