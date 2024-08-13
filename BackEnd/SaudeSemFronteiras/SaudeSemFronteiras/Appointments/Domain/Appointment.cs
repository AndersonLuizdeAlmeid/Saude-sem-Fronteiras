namespace SaudeSemFronteiras.Application.Appointments.Domain;
public class Appointment
{
    public long Id { get; private set; }
    public DateTime Time { get; private set; }
    public decimal Duration { get; private set; }
    public long DoctorId { get; private set; }
    public long PatientId { get; private set; }

    public Appointment(long id, DateTime time, decimal duration, long doctorId, long patientId)
    {
        Id = id;
        Time = time;
        Duration = duration;
        DoctorId = doctorId;
        PatientId = patientId;
    }

    public static Appointment Create(DateTime time, decimal duration, long doctorId, long patientId) =>
        new(0, time, duration, doctorId, patientId);

    public void Update(DateTime time, decimal duration, long doctorId, long patientId)
    {
        Time = time;
        Duration = duration;
        DoctorId = doctorId;
        PatientId = patientId;
    }
}
