using SaudeSemFronteiras.Application.Documents.Domain;
using SaudeSemFronteiras.Application.Documents.Dtos;

namespace SaudeSemFronteiras.Application.Documents.Queries;
public interface IDocumentQueries
{
    Task<IEnumerable<DocumentDto>> GetAll(CancellationToken cancellationToken);
    Task<Document?> GetById(long iD, CancellationToken cancellationToken);
}
