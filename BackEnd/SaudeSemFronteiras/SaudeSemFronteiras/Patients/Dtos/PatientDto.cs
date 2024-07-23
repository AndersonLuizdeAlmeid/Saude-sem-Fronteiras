namespace SaudeSemFronteiras.Application.Patients.Dtos;
public class PatientDto
{
    public long Id { get; set; }
    public string BloodType { get; set; } = string.Empty;
    public string Allergies { get; set; } = string.Empty;
    public string MedicalCondition { get; set; } = string.Empty;
    public string PreviousSurgeries { get; set; } = string.Empty;
    public string Medicines { get; set; } = string.Empty;
    public string EmergencyNumber { get; set; } = string.Empty;
    public long UserId { get; set; }
}
