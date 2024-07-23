namespace SaudeSemFronteiras.Application.Patients.Domain;
public class Patient
{
    public long Id { get; private set; }
    public string BloodType { get; private set; } = string.Empty;
    public string Allergies { get; private set; } = string.Empty;
    public string MedicalCondition { get; private set; } = string.Empty;
    public string PreviousSurgeries { get;  private set; } = string.Empty;
    public string Medicines { get;  private set; } = string.Empty;
    public string EmergencyNumber { get; private set; } = string.Empty;
    public long UserId { get; private set; }

    public Patient(long id, string bloodType, string allergies, string medicalCondition, string previousSurgeries, string medicines, string emergencyNumber, long userId)
    {
        Id = id;
        BloodType = bloodType;
        Allergies = allergies;
        MedicalCondition = medicalCondition;
        PreviousSurgeries = previousSurgeries;
        Medicines = medicines;
        EmergencyNumber = emergencyNumber;
        UserId = userId;
    }

    public static Patient Create(string bloodType, string allergies, string medicalCondition, string previousSurgeries, string medicines, string emergencyNumber, long userId) =>
        new(0, bloodType, allergies, medicalCondition, previousSurgeries, medicines, emergencyNumber, userId);

    public void Update(string bloodType, string allergies, string medicalCondition, string previousSurgeries, string medicines, string emergencyNumber, long userId)
    {
        BloodType = bloodType;
        Allergies = allergies;
        MedicalCondition = medicalCondition;
        PreviousSurgeries = previousSurgeries;
        Medicines = medicines;
        EmergencyNumber = emergencyNumber;
        UserId = userId;
    }
}
