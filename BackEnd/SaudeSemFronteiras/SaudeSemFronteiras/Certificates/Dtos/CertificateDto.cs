namespace SaudeSemFronteiras.Application.Certificates.Dtos;
public class CertificateDto
{
    public long Id { get; set; }
    public DateTime IssuanceDate { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime FinalDate { get; set; }
    public string Observations { get; set; } = string.Empty;
    public long DocumentId { get; set; }
}
