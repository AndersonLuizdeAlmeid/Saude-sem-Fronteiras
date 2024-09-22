namespace SaudeSemFronteiras.Application.Screenings.Dtos;
public class ScreeningDto
{
    public long Id { get; set; }
    public string Symptons { get; set; } = string.Empty;
    public string DateSymptons { get; set; } = string.Empty;
    public string ContinuosMedicine { get; set; } = string.Empty;
    public string Allergies { get; set; } = string.Empty;
    public string Observations {  get; set; } = string.Empty;
    public long EmergencyId { get; set; }
}
