using SaudeSemFronteiras.Application.Prescriptions.Domain;

namespace SaudeSemFronteiras.Application.Medicines.Domain;
public class Medicine
{
    public long Id { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public string Quantity { get; private set; } = string.Empty;
    public string Dosage { get; private set; } = string.Empty;
    public string Observation { get; private set; } = string.Empty;
    public long PrescriptionId { get; private set; }

    public Medicine(long id, string description, string quantity, string dosage, string observation, long prescriptionId)
    {
        Id = id;
        Description = description;
        Quantity = quantity;
        Dosage = dosage;
        Observation = observation;
        PrescriptionId = prescriptionId;
    }

    public static Medicine Create(string description, string quantity, string dosage, string observation, long prescriptionId) =>
        new(0, description, quantity, dosage, observation, prescriptionId);

    public void Update(string description, string quantity, string dosage, string observation, long prescriptionId)
    {
        Description = description;
        Quantity = quantity;
        Dosage = dosage;
        Observation = observation;
        PrescriptionId = prescriptionId;
    }
}
