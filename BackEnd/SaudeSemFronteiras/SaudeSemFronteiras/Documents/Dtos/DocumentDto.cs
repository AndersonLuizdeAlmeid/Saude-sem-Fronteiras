namespace SaudeSemFronteiras.Application.Documents.Dtos;
public class DocumentDto
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public short TypeDocument { get; set; }
    public DateTime DateDocument { get; set; }
    //:TODO VERIFICAR COMO CRIAR ASSINATURA DIGITAL
    public short DigitallySigned { get; set; }
    public long AppointmentId { get; set; }
}
