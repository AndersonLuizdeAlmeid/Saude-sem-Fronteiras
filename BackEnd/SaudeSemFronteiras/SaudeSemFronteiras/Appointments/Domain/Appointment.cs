namespace SaudeSemFronteiras.Application.Appointments.Domain;
public class Appointment
{
    public long Id { get; private set; }
    public DateTime Time { get; private set; }
    public decimal Duration { get; private set; }
    public Appointment(long id, DateTime time, decimal duration)
    {
        Id = id;
        Time = time;
        Duration = duration;
    }

    public static Appointment Create(DateTime time, decimal duration) =>
        new(0, time, duration);

    public void Update(DateTime time, decimal duration)
    {
        Time = time;
        Duration = duration;
    }
}
