namespace SaudeSemFronteiras.Application.Screenings.Domain;
public class Screening
{
    public long Id { get; private set; }
    public string DegreeSeverity { get; private set; } = string.Empty;
    public string Symptons { get; private set; } = string.Empty;
    public DateTime DateSymptons { get; private set; }
    public string ContinuosMedicine { get; private set; } = string.Empty;
    public string Allergies { get; private set; } = string.Empty;
    public long EmergencyId { get; private set; }

    public Screening(long id, string degreeSeverity, string symptons, DateTime dateSymptons, string continuosMedicine, string allergies, long emergencyId)
    {
        Id = id;
        DegreeSeverity = degreeSeverity;
        Symptons = symptons;
        DateSymptons = dateSymptons;
        ContinuosMedicine = continuosMedicine;
        Allergies = allergies;
        EmergencyId = emergencyId;
    }

    public static Screening Create(string degreeSeverity, string symptons, DateTime dateSymptons, string continuosMedicine, string allergies, long emergencyId) =>
        new(0, degreeSeverity, symptons, dateSymptons, continuosMedicine, allergies, emergencyId);

    public void Update(string degreeSeverity, string symptons, DateTime dateSymptons, string continuosMedicine, string allergies, long emergencyId)
    {
        DegreeSeverity = degreeSeverity;
        Symptons = symptons;
        DateSymptons = dateSymptons;
        ContinuosMedicine = continuosMedicine;
        Allergies = allergies;
        EmergencyId = emergencyId;
    }
}
