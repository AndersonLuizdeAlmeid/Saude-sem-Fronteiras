namespace SaudeSemFronteiras.Application.Scheduled.Domain;
public class Schedule
{
    public long Id { get; private set; }
    public string Value { get; private set; } = string.Empty;
    public DateTime ScheduledDate { get; private set; }
    public bool IsActive { get; private set; }
    public long AppointmentId { get; private set; }

    public Schedule(long id, string value, DateTime scheduledDate, bool isActive, long appointmentId)
    {
        Id = id;
        Value = value;
        ScheduledDate = scheduledDate;
        IsActive = isActive;
        AppointmentId = appointmentId;
    }

    public static Schedule Create(string value, DateTime scheduledDate, long appointmentId) =>
        new (0, value, scheduledDate, true, appointmentId);

    public void Update(string value, DateTime scheduledDate, bool isActive, long appointmentId)
    {
        Value = value;
        ScheduledDate = scheduledDate;
        IsActive = isActive;
        AppointmentId = appointmentId;
    }
}
