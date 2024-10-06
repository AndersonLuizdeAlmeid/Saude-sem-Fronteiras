using SaudeSemFronteiras.Application.Specialities.Domain;
using SaudeSemFronteiras.Application.Specialities.Dtos;

namespace SaudeSemFronteiras.Application.Specialities.Queries;
public interface ISpecialityQueries
{
    Task<IEnumerable<SpecilitiesShowDto>> GetAll(CancellationToken cancellationToken);
    Task<IEnumerable<SpecilitiesShowDto>> GetAllSpecialitiesByDoctorId(long doctorId,CancellationToken cancellationToken);
    Task<Speciality?> GetById(long iD, CancellationToken cancellationToken);
}
