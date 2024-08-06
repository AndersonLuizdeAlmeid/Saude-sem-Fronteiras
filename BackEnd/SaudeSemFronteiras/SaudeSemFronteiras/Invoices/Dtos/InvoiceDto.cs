namespace SaudeSemFronteiras.Application.Invoices.Dtos;
public class InvoiceDto
{
    public long Id { get; set; }
    public DateTime IssuanceDate { get; set; }
    public DateTime DueDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string Tax { get; set; } = string.Empty;
    public string Discount { get; set; } = string.Empty;
    public string Terms { get; set; } = string.Empty;
    public long AppointmentId { get; set; }
}
