using SaudeSemFronteiras.Application.Specialities.Domain;

namespace SaudeSemFronteiras.Application.Specialities.Repository;
public interface ISpecialityRepository
{
    Task Insert(Speciality speciality, CancellationToken cancellationToken);
    Task Update(Speciality speciality, CancellationToken cancellationToken);
    Task Delete(long iD, CancellationToken cancellationToken);
}
