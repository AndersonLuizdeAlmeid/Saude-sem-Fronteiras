using SaudeSemFronteiras.Application.Emergencys.Domain;
using SaudeSemFronteiras.Application.Emergencys.Dtos;

namespace SaudeSemFronteiras.Application.Emergencys.Queries;
public interface IEmergencyQueries
{
    Task<IEnumerable<EmergencyDto>> GetAll(CancellationToken cancellationToken);
    Task<Emergency?> GetById(long iD, CancellationToken cancellationToken);
}
