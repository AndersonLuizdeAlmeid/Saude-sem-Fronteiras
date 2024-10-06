using SaudeSemFronteiras.Application.Documents.Domain;

namespace SaudeSemFronteiras.Application.Documents.Repository;
public interface IDocumentRepository
{
    Task Insert(Document document, CancellationToken cancellationToken);
    Task Update(Document document, CancellationToken cancellationToken);
    Task Delete(long iD, CancellationToken cancellationToken);
}
