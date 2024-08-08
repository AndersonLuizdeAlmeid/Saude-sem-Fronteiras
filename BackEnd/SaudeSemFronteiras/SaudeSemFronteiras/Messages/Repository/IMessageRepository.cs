using SaudeSemFronteiras.Application.Messages.Domain;

namespace SaudeSemFronteiras.Application.Messages.Repository;
public interface IMessageRepository
{
    Task Insert(Message message, CancellationToken cancellationToken);
    Task Update(Message message, CancellationToken cancellationToken);
}
