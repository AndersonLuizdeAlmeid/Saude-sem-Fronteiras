using SaudeSemFronteiras.Application.Countries.Dtos;

namespace SaudeSemFronteiras.Application.Countries.Queries;
public interface ICountryQueries
{
    Task<IEnumerable<CountryDto>> GetAll(CancellationToken cancellationToken);
    Task<CountryDto> GetById(long iD, CancellationToken cancellationToken);
    Task<short> GetCountryCountable();
}
