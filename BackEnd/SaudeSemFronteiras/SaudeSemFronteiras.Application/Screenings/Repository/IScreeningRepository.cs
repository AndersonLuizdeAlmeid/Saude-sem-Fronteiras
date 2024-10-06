using SaudeSemFronteiras.Application.Screenings.Domain;

namespace SaudeSemFronteiras.Application.Screenings.Repository;
public interface IScreeningRepository
{
    Task Insert(Screening Screening, CancellationToken cancellationToken);
    Task Update(Screening Screening, CancellationToken cancellationToken);
}
