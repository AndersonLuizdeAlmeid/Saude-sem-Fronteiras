using SaudeSemFronteiras.Application.Emergencys.Domain;

namespace SaudeSemFronteiras.Application.Emergencys.Repository;
public interface IEmergencyRepository
{
    Task<Emergency?> GetById(long iD, CancellationToken cancellationToken);
    Task Insert(Emergency emergency, CancellationToken cancellationToken);
    Task Update(Emergency emergency, CancellationToken cancellationToken)
}
