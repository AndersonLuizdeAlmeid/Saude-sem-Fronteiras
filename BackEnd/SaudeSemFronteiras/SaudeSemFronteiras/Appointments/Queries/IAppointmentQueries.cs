using SaudeSemFronteiras.Application.Appointments.Domain;
using SaudeSemFronteiras.Application.Appointments.Dtos;
using SaudeSemFronteiras.Application.Patients.Domain;

namespace SaudeSemFronteiras.Application.Appointments.Queries;
public interface IAppointmentQueries
{
    Task<IEnumerable<AppointmentDto>> GetAll(CancellationToken cancellationToken);
    Task<Appointment?> GetById(long iD, CancellationToken cancellationToken);
    Task<long?> GetPatientIdByAppointmentId(long iD, CancellationToken cancellationToken);
    Task<int> GetAppointmentByDate(DateTime date, CancellationToken cancellationToken);
    Task<IEnumerable<AppointmentDto?>> GetAllFreeTimeByDoctor(long iD, DateOnly date, CancellationToken cancellationToken);
    Task<IEnumerable<AppointmentShowDto?>> GetAppointmentsByPatientId(long patientId, CancellationToken cancellationToken);
    Task<IEnumerable<AppointmentShowDto?>> GetAppointmentsByDoctorId(long patientId, CancellationToken cancellationToken);
    Task<string> GetPhoneByPatient(long appointmentId, long patientId, CancellationToken cancellationToken);
    Task<long> GetLastAppointmentByPatientAndDoctor(long doctor_id, long patient_id, CancellationToken cancellationToken);
    Task<long> GetLastAppointmentByPatientQuery(long patientId, CancellationToken cancellationToken);
    Task<string> GetDateByEmergencyIdQuery(long emergencyId, CancellationToken cancellationToken);
}