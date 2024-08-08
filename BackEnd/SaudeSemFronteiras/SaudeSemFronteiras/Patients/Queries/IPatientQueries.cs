using SaudeSemFronteiras.Application.Patients.Domain;
using SaudeSemFronteiras.Application.Patients.Dtos;

namespace SaudeSemFronteiras.Application.Patients.Queries;
public interface IPatientQueries
{
    Task<IEnumerable<PatientDto>> GetAll(CancellationToken cancellationToken);
    Task<Patient?> GetById(long iD, CancellationToken cancellationToken);
}
