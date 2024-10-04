using SaudeSemFronteiras.Application.Screenings.Domain;
using SaudeSemFronteiras.Application.Screenings.Dtos;

namespace SaudeSemFronteiras.Application.Screenings.Queries;
public interface IScreeningQueries
{
    Task<IEnumerable<ScreeningDto>> GetAll(CancellationToken cancellationToken);
    Task<Screening?> GetById(long iD, CancellationToken cancellationToken);
    Task<ScreeningDto?> GetDataOfScreeningByEmergencyIdQuery(long iD, CancellationToken cancellationToken);

}
