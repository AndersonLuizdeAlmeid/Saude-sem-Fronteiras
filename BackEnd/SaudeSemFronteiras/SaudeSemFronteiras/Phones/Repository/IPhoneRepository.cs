using SaudeSemFronteiras.Application.Phones.Domain;

namespace SaudeSemFronteiras.Application.Phones.Repository;
public interface IPhoneRepository
{
    Task Insert(Phone phone, CancellationToken cancellationToken);
    Task Update(Phone phone, CancellationToken cancellationToken);
}
