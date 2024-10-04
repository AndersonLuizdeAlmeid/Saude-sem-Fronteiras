namespace SaudeSemFronteiras.Application.Certificates.Dtos;
public class CertificateShowDto
{
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public short Days { get; set; }
    public long Cid { get; set; }
    public string NameDoctor { get; set; } = string.Empty;
    public string Crm {  get; set; } = string.Empty;
    public string CityDescription { get; set; } = string.Empty;
}
