using SaudeSemFronteiras.Application.Messages.Domain;

namespace SaudeSemFronteiras.Application.Messages.Repository;
public interface IMessageRepository
{
    Task<Message?> GetById(long iD, CancellationToken cancellationToken);
    Task Insert(Message message, CancellationToken cancellationToken);
    Task Update(Message message, CancellationToken cancellationToken);
}
