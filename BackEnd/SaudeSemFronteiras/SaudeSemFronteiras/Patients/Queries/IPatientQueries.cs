using SaudeSemFronteiras.Application.Patients.Domain;
using SaudeSemFronteiras.Application.Patients.Dtos;

namespace SaudeSemFronteiras.Application.Patients.Queries;
public interface IPatientQueries
{
    Task<IEnumerable<PatientDto>> GetAll(CancellationToken cancellationToken);
    Task<Patient?> GetById(long iD, CancellationToken cancellationToken);
    Task<Patient?> GetByUserIdChange(long iD, CancellationToken cancellationToken);
    Task<PatientDto?> GetByUserId(long iD, CancellationToken cancellationToken);
    Task<string?> GetUserNameByPatientIdQuery(long iD, CancellationToken cancellationToken);
    Task<string?> GetUserCpfByPatientIdQuery(long iD, CancellationToken cancellationToken);
}
