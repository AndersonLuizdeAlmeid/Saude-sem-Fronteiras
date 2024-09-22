namespace SaudeSemFronteiras.Application.Appointments.Domain;
public class Appointment
{
    public long Id { get; private set; }
    public DateTime Date { get; private set; }
    public decimal Duration { get; private set; }
    public long ?DoctorId { get; private set; }
    public long PatientId { get; private set; }

    public Appointment(long id, DateTime date, decimal duration, long ?doctorId, long patientId)
    {
        Id = id;
        Date = date;
        Duration = duration;
        DoctorId = doctorId;
        PatientId = patientId;
    }

    public static Appointment Create(DateTime date, decimal duration, long ?doctorId, long patientId) =>
        new(0, date, duration, doctorId, patientId);

    public void Update(DateTime date, decimal duration, long ?doctorId, long patientId)
    {
        Date = date;
        Duration = duration;
        DoctorId = doctorId;
        PatientId = patientId;
    }
}
