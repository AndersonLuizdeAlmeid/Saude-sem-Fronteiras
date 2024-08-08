using SaudeSemFronteiras.Application.Scheduled.Domain;
using SaudeSemFronteiras.Application.Scheduled.Dtos;

namespace SaudeSemFronteiras.Application.Scheduled.Queries;
public interface IScheduleQueries
{
    Task<IEnumerable<ScheduleDto>> GetAll(CancellationToken cancellationToken);
    Task<Schedule?> GetById(long iD, CancellationToken cancellationToken);
}
