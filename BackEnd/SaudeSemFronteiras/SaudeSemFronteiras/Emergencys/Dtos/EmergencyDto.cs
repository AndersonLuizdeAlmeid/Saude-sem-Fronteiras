namespace SaudeSemFronteiras.Application.Emergencys.Dtos;
public class EmergencyDto
{
    public long Id { get; set; }
    public string Value { get; set; } = string.Empty;
    public DateTime WaitTime { get; set; }
    public bool IsActive { get; set; }
    public long AppointmentId { get; set; }
}
