namespace SaudeSemFronteiras.Application.Scheduled.Domain;
public class Schedule
{
    public long Id { get; private set; }
    public decimal Price {  get; private set; }
    public DateTime ScheduledDate { get; private set; }
    public short Status { get; private set; }
    public long AppointmentId { get; private set; }

    public Schedule(long id, decimal price, DateTime scheduledDate, short status, long appointmentId)
    {
        Id = id;
        Price = price;
        ScheduledDate = scheduledDate;
        Status = status;
        AppointmentId = appointmentId;
    }

    public static Schedule Create(decimal price, DateTime scheduledDate, long appointmentId) =>
        new (0, price, scheduledDate, 1, appointmentId);

    public void Update(decimal price, short status)
    {
        Price = price;
        Status = status;
    }
}
