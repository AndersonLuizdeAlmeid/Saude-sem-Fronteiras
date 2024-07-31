using SaudeSemFronteiras.Application.Prescriptions.Domain;

namespace SaudeSemFronteiras.Application.Certificates.Domain;

public class Certificate
{
    public long Id { get; private set; }
    public DateTime IssuanceDate { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime StartDate { get; private set; }
    public DateTime FinalDate { get; private set; }
    public string Observations { get; private set; } = string.Empty;
    public long DocumentId { get; private set; }

    public Certificate(long id, DateTime issuanceDate, string title, string description, DateTime startDate, DateTime finalDate, string observations, long documentId)
    {
        Id = id;
        IssuanceDate = issuanceDate;
        Title = title;
        Description = description;
        StartDate = startDate;
        FinalDate = finalDate;
        Observations = observations;
        DocumentId = documentId;
    }

    public static Certificate Create(string title, string description, DateTime startDate, DateTime finalDate, string observations, long documentId) =>
        new(0, DateTime.Now, title, description, startDate, finalDate, observations, documentId);

    public void Update(DateTime issuanceDate, string title, string description, DateTime startDate, DateTime finalDate, string observations, long documentId)
    {
        IssuanceDate = issuanceDate;
        Title = title;
        Description = description;
        StartDate = startDate;
        FinalDate = finalDate;
        Observations = observations;
        DocumentId = documentId;
    }
}
