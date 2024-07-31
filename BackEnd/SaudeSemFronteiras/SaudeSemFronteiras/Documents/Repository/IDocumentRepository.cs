using SaudeSemFronteiras.Application.Documents.Domain;

namespace SaudeSemFronteiras.Application.Documents.Repository;
public interface IDocumentRepository
{
    Task<Document?> GetById(long iD, CancellationToken cancellationToken);
    Task Insert(Document document, CancellationToken cancellationToken);
    Task Update(Document document, CancellationToken cancellationToken);
}
