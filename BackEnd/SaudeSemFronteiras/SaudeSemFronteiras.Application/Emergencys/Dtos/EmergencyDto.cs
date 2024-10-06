namespace SaudeSemFronteiras.Application.Emergencys.Dtos;
public class EmergencyDto
{
    public long Id { get; set; }
    public decimal Price { get; set; }
    public string WaitTime { get; set; } = string.Empty;
    public short Status { get; set; }
    public long AppointmentId { get; set; }
}
