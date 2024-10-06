using SaudeSemFronteiras.Application.Countries.Dtos;
using SaudeSemFronteiras.Application.States.Dtos;

namespace SaudeSemFronteiras.Application.States.Queries;
public interface IStateQueries
{
    Task<IEnumerable<StateDto>> GetAll(CancellationToken cancellationToken);
    Task<StateDto> GetById(long iD, CancellationToken cancellationToken);
    Task<IEnumerable<StateDto>> GetByCountryId(long countryId, CancellationToken cancellationToken);

}
