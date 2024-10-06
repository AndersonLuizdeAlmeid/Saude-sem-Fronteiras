namespace SaudeSemFronteiras.Application.Medicines.Dtos;
public class MedicineDto
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
    public string Observation { get; set; } = string.Empty;
    public long PrescriptionId { get; set; }
}
