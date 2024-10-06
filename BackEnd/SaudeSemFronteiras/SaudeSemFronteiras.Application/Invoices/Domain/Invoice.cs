namespace SaudeSemFronteiras.Application.Invoices.Domain;

public class Invoice
{
    public long Id { get; private set; }
    public DateTime IssuanceDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public string Status { get; private set; } = string.Empty;
    public string Value { get; private set; } = string.Empty;
    public string Tax { get; private set; } = string.Empty;
    public string Discount { get; private set; } = string.Empty;
    public string Terms { get; private set; } = string.Empty;
    public long AppointmentId { get; private set; }

    public Invoice(long id, DateTime issuanceDate, DateTime dueDate, string description, string status, string value, string tax, string discount, string terms, long appointmentId)
    {
        Id = id;
        IssuanceDate = issuanceDate;
        DueDate = dueDate;
        Description = description;
        Status = status;
        Value = value;
        Tax = tax;
        Discount = discount;
        Terms = terms;
        AppointmentId = appointmentId;
    }

    public static Invoice Create(DateTime dueDate, string description, string status, string value, string tax, string discount, string terms, long appointmentId) =>
        new(0, DateTime.Now, dueDate, description, status, value, tax, discount, terms, appointmentId);

    public void Update(DateTime issuanceDate, DateTime dueDate, string description, string status, string value, string tax, string discount, string terms, long appointmentId)
    {
        IssuanceDate = issuanceDate;
        DueDate = dueDate;
        Description = description;
        Status = status;
        Value = value;
        Tax = tax;
        Discount = discount;
        Terms = terms;
        AppointmentId = appointmentId;
    }
}
