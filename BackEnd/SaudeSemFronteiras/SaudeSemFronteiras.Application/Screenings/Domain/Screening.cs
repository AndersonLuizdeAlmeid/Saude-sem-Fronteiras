namespace SaudeSemFronteiras.Application.Screenings.Domain;
public class Screening
{
    public long Id { get; private set; }
    public string Symptons { get; private set; } = string.Empty;
    public string DateSymptons { get; private set; }
    public string ContinuosMedicine { get; private set; } = string.Empty;
    public string Allergies { get; private set; } = string.Empty;
    public string Observations { get; private set; } = string.Empty;
    public long EmergencyId { get; private set; }

    public Screening(long id, string symptons, string dateSymptons, string continuosMedicine, string allergies, string observations, long emergencyId)
    {
        Id = id;
        Symptons = symptons;
        DateSymptons = dateSymptons;
        ContinuosMedicine = continuosMedicine;
        Allergies = allergies;
        Observations = observations;
        EmergencyId = emergencyId;
    }

    public static Screening Create(string symptons, string dateSymptons, string continuosMedicine, string allergies, string observations, long emergencyId) =>
        new(0, symptons, dateSymptons, continuosMedicine, allergies, observations, emergencyId);

    public void Update(string symptons, string dateSymptons, string continuosMedicine, string allergies, string observations, long emergencyId)
    {
        Symptons = symptons;
        DateSymptons = dateSymptons;
        ContinuosMedicine = continuosMedicine;
        Allergies = allergies;
        Observations = observations;
        EmergencyId = emergencyId;
    }
}
