namespace SaudeSemFronteiras.Application.Prescriptions.Dtos;
public class PrescriptionDto
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public long DocumentId { get; set; }
}
