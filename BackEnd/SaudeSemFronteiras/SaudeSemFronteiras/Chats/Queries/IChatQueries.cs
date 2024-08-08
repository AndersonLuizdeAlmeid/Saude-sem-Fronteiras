using SaudeSemFronteiras.Application.Chats.Domain;
using SaudeSemFronteiras.Application.Chats.Dtos;

namespace SaudeSemFronteiras.Application.Chats.Queries;

public interface IChatQueries
{
    Task<IEnumerable<ChatDto>> GetAll(CancellationToken cancellationToken);
    Task<Chat?> GetById(long iD, CancellationToken cancellationToken);
}
