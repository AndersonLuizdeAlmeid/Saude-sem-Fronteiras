using SaudeSemFronteiras.Application.Cities.Dtos;

namespace SaudeSemFronteiras.Application.Cities.Queries;
public interface ICityQueries
{
    Task<IEnumerable<CityDto>> GetAll(CancellationToken cancellationToken);
    Task<CityDto> GetById(long iD, CancellationToken cancellationToken);
    Task<IEnumerable<CityDto>> GetByStateId(long stateId, CancellationToken cancellationToken);
}
