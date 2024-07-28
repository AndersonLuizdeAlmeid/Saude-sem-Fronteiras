namespace SaudeSemFronteiras.Application.Screenings.Dtos;
public class ScreeningDto
{
    public long Id { get; set; }
    public string DegreeSeverity { get; set; } = string.Empty;
    public string Symptons { get; set; } = string.Empty;
    public DateTime DateSymptons { get; set; }
    public string ContinuosMedicine { get; set; } = string.Empty;
    public string Allergies { get; set; } = string.Empty;
    public long EmergencyId { get; set; }
}
