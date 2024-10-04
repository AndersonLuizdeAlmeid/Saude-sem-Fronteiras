namespace SaudeSemFronteiras.Application.Documents.Dtos;
public class DocumentDto
{
    public long Id { get; set; }
    public short TypeDocument { get; set; }
    public DateTime DateDocument { get; set; }
    public long AppointmentId { get; set; }
}
