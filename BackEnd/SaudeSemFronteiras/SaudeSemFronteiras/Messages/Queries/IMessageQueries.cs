using SaudeSemFronteiras.Application.Messages.Domain;
using SaudeSemFronteiras.Application.Messages.Dtos;

namespace SaudeSemFronteiras.Application.Messages.Queries;

public interface IMessageQueries
{
    Task<IEnumerable<MessageDto>> GetAll(CancellationToken cancellationToken);
    Task<Message?> GetById(long iD, CancellationToken cancellationToken);
}
