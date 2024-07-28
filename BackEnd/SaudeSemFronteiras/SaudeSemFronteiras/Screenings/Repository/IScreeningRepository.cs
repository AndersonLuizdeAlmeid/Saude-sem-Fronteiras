using SaudeSemFronteiras.Application.Screenings.Domain;

namespace SaudeSemFronteiras.Application.Screenings.Repository;
public interface IScreeningRepository
{
    Task<Screening?> GetById(long iD, CancellationToken cancellationToken);
    Task Insert(Screening Screening, CancellationToken cancellationToken);
    Task Update(Screening Screening, CancellationToken cancellationToken);
}
