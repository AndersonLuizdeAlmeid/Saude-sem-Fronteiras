namespace SaudeSemFronteiras.Application.Prescriptions.Domain;

public class Prescription
{
    public long Id { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public long DocumentId { get; private set; }

    public Prescription(long id, string description, long documentId)
    {
        Id = id;
        Description = description;
        DocumentId = documentId;
    }

    public static Prescription Create(string description, long documentId) =>
        new(0, description, documentId);

    public void Update(string description, long documentId)
    {
        Description = description;
        DocumentId = documentId;
    }
}
