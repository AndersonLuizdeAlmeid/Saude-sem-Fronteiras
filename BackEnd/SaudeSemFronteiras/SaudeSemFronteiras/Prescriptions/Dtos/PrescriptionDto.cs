namespace SaudeSemFronteiras.Application.Prescriptions.Dtos;
public class PrescriptionDto
{
    public long Id { get; set; }
    public DateTime IssuanceDate { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public DateTime FinalDate { get; set; }
    public string Observations { get; set; } = string.Empty;
    public DateTime PrescriptionValidate { get; set; }
    public long DocumentId { get; set; }
}
