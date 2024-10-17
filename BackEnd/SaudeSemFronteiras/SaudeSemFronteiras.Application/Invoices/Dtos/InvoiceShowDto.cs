namespace SaudeSemFronteiras.Application.Invoices.Dtos;
public class InvoiceShowDto
{
    public long Id { get; set; }
    public short Status { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
