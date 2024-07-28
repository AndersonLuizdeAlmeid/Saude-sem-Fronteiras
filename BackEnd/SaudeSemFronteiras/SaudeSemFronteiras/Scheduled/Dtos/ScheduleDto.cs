namespace SaudeSemFronteiras.Application.Scheduled.Dtos;
public class ScheduleDto
{
    public long Id { get; set; }
    public string Value { get; set; } = string.Empty;
    public DateTime ScheduledDate { get; set; }
    public bool IsActive { get; set; }
    public long AppointmentId { get; set; }
}
