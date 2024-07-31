namespace SaudeSemFronteiras.Application.Prescriptions.Domain;

public class Prescription
{
    public long Id { get; private set; }
    public DateTime IssuanceDate { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Instructions { get; private set; } = string.Empty;
    public DateTime FinalDate { get; private set; }
    public string Observations { get; private set; } = string.Empty;
    public DateTime PrescriptionValidate { get; private set; }
    public long DocumentId { get; private set; }

    public Prescription(long id, DateTime issuanceDate, string title, string description, string instructions, DateTime finalDate, string observations, DateTime prescriptionValidate, long documentId)
    {
        Id = id;
        IssuanceDate = issuanceDate;
        Title = title;
        Description = description;
        Instructions = instructions;
        FinalDate = finalDate;
        Observations = observations;
        PrescriptionValidate = prescriptionValidate;
        DocumentId = documentId;
    }

    public static Prescription Create(string title, string description, string instructions, DateTime finalDate, string observations, DateTime prescriptionValidate, long documentId) =>
        new(0, DateTime.Now, title, description, instructions, finalDate, observations, prescriptionValidate, documentId);

    public void Update(DateTime issuanceDate, string title, string description, string instructions, DateTime finalDate, string observations, DateTime prescriptionValidate, long documentId)
    {
        IssuanceDate = issuanceDate;
        Title = title;
        Description = description;
        Instructions = instructions;
        FinalDate = finalDate;
        Observations = observations;
        PrescriptionValidate = prescriptionValidate;
        DocumentId = documentId;
    }
}
