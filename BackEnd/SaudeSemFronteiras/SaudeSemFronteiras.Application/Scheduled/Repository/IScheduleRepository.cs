using SaudeSemFronteiras.Application.Scheduled.Domain;

namespace SaudeSemFronteiras.Application.Scheduled.Repository;
public interface IScheduleRepository
{
    Task Insert(Schedule schedule, CancellationToken cancellationToken);
    Task Update(Schedule schedule, CancellationToken cancellationToken);
}
