using SaudeSemFronteiras.Application.Specialities.Domain;
using SaudeSemFronteiras.Application.Specialities.Dtos;

namespace SaudeSemFronteiras.Application.Specialities.Queries;
public interface ISpecialityQueries
{
    Task<IEnumerable<SpecialityDto>> GetAll(CancellationToken cancellationToken);
    Task<Speciality?> GetById(long iD, CancellationToken cancellationToken);
}
