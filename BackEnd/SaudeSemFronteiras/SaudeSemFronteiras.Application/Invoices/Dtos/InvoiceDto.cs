namespace SaudeSemFronteiras.Application.Invoices.Dtos;
public class InvoiceDto
{
    public long Id { get; set; }
    public DateTime IssuanceDate { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Value { get; set; }
    public short Status { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Agency { get; set; } = string.Empty;
    public string Account { get; set; } = string.Empty;
    public string Digit { get; set; } = string.Empty;
    public string StandardWallet { get; set; } = string.Empty;
    public long PatientId { get; set; }
    public long DoctorId { get; set; }
    public long AppointmentId { get; set; }
}
