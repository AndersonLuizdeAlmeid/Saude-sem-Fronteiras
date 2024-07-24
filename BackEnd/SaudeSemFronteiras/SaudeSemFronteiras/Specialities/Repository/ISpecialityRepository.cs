using SaudeSemFronteiras.Application.Specialities.Domain;

namespace SaudeSemFronteiras.Application.Specialities.Repository;
public interface ISpecialityRepository
{
    Task<Speciality?> GetById(long iD, CancellationToken cancellationToken);
    Task Insert(Speciality speciality, CancellationToken cancellationToken);
    Task Update(Speciality speciality, CancellationToken cancellationToken);
}
