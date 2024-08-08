using SaudeSemFronteiras.Application.Addresses.Domain;
using SaudeSemFronteiras.Application.Addresses.Dtos;

namespace SaudeSemFronteiras.Application.Addresses.Queries;
public interface IAddressQueries
{
    Task<IEnumerable<AddressDto>> GetAll(CancellationToken cancellationToken);
    Task<Address?> GetById(long iD, CancellationToken cancellationToken);
}
