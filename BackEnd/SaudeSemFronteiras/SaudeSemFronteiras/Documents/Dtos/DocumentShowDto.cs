namespace SaudeSemFronteiras.Application.Documents.Dtos;
public class DocumentShowDto
{
    public long Id { get; set; }
    public short Type { get; set; }
    public string Name {  get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
