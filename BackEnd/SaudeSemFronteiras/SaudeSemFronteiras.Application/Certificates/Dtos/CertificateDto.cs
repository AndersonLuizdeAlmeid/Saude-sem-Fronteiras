namespace SaudeSemFronteiras.Application.Certificates.Dtos;
public class CertificateDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public short Days { get; set; }
    public long Cid  { get; set; }
    public long DocumentId { get; set; }
}
