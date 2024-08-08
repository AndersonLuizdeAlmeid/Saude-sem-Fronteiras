using SaudeSemFronteiras.Application.Addresses.Domain;

namespace SaudeSemFronteiras.Application.Addresses.Repositories;
public interface IAddressRepository
{
    Task Insert(Address address, CancellationToken cancellationToken);
    Task Update(Address address, CancellationToken cancellationToken);
}
