namespace SaudeSemFronteiras.Application.Scheduled.Dtos;
public class ScheduleDto
{
    public long Id { get; set; }
    public decimal Price { get; set; }
    public DateTime ScheduledDate { get; set; }
    public short Status { get; set; }
    public long AppointmentId { get; set; }
}
