using SaudeSemFronteiras.Application.Appointments.Dtos;
using SaudeSemFronteiras.Application.Emergencys.Dtos;

namespace SaudeSemFronteiras.Application.Emergencys.Queries;
public interface IEmergencyQueries
{
    Task<IEnumerable<EmergencyDto>> GetAll(CancellationToken cancellationToken);
    Task<EmergencyDto?> GetById(long iD, CancellationToken cancellationToken);
    Task<IEnumerable<EmergencyShowDto?>> GetEmergenciesByPatientId(long patientId, CancellationToken cancellationToken);
    Task<long> GetLastEmergencyByPatientQuery(long patientId, CancellationToken cancellationToken);
    Task<IEnumerable<EmergencyShowDto?>> GetEmergenciesByDoctorIdQuery(long doctorId, CancellationToken cancellationToken);
    Task<string> GetPhoneByPatientQuery(long emergencyId, CancellationToken cancellationToken);
    Task<AppointmentDto?> GetAppointmentByEmergencyIdQuery(long emergencyId, CancellationToken cancellationToken);
}


