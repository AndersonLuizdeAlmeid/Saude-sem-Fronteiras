using SaudeSemFronteiras.Application.Emergencys.Domain;

namespace SaudeSemFronteiras.Application.Emergencys.Repository;
public interface IEmergencyRepository
{
    Task Insert(Emergency emergency, CancellationToken cancellationToken);
    Task Update(Emergency emergency, CancellationToken cancellationToken);
}
