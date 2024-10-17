namespace SaudeSemFronteiras.Application.Invoices.Dtos;
public class InvoiceCompleteDto
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
    public string CpfPayer { get; set; } = string.Empty;
    public string NamePayer { get; set; } = string.Empty;
    public string StreetPayer { get; set; } = string.Empty;
    public string NumberPayer { get; set; } = string.Empty;
    public string DistrictPayer { get; set; } = string.Empty;
    public string UfPayer {  get; set; } = string.Empty;
    public string CepPayer { get; set; } = string.Empty;
    public string CityDescriptionPayer { get; set; } = string.Empty;
    public string ComplementPayer { get; set; } = string.Empty;
    public string CpfReceiver { get; set; } = string.Empty;
    public string NameReceiver { get; set; } = string.Empty;
    public string StreetReceiver { get; set; } = string.Empty;
    public string NumberReceiver { get; set; } = string.Empty;
    public string DistrictReceiver { get; set; } = string.Empty;
    public string UfReceiver { get; set; } = string.Empty;
    public string CepReceiver { get; set; } = string.Empty;
    public string CityDescriptionReceiver { get; set; } = string.Empty;
    public string ComplementReceiver { get; set; } = string.Empty;
}
