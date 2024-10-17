namespace SaudeSemFronteiras.Application.Invoices.Domain;

public class Invoice
{
    public long Id { get; private set; }
    public DateTime IssuanceDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public decimal Value { get; private set; }
    public short Status { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public string Agency { get; private set; } = string.Empty;
    public string Account { get; private set; } = string.Empty;
    public string Digit { get; private set; } = string.Empty;
    public string StandardWallet { get; private set; } = string.Empty;
    public long PatientId { get; private set; }
    public long DoctorId { get; private set; }
    public long AppointmentId { get; private set; }

    public Invoice(long id, DateTime issuanceDate, DateTime dueDate, decimal value, short status, string description, string agency, string account, string digit, string standardWallet, long patientId, long doctorId, long appointmentId)
    {
        Id = id;
        IssuanceDate = issuanceDate;
        DueDate = dueDate;
        Value = value;
        Status = status;
        Description = description;
        Agency = agency;
        Account = account;
        Digit = digit;
        StandardWallet = standardWallet;
        PatientId = patientId;
        DoctorId = doctorId;
        AppointmentId = appointmentId;
    }

    public static Invoice Create(DateTime dueDate, decimal value, short status, string description, string agency, string account, string digit, string standardWallet, long patientId, long doctorId, long appointmentId) =>
        new(0, DateTime.Now, dueDate, value, status, description, agency, account, digit, standardWallet, patientId, doctorId, appointmentId);

    public void Update(DateTime issuanceDate, DateTime dueDate, decimal value, short status, string description, string agency, string account, string digit, string standardWallet, long patientId, long doctorId, long appointmentId)
    {
        IssuanceDate = issuanceDate;
        Status = status;
    }
}
