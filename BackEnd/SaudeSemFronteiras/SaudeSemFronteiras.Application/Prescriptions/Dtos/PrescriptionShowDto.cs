namespace SaudeSemFronteiras.Application.Prescriptions.Dtos;
public class PrescriptionShowDto
{
    public string NamePatient { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Quantity {  get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
    public string Observation { get; set; } = string.Empty;
    public DateTime Date {  get; set; } 
    public string City {  get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string NameDoctor { get; set; } = string.Empty;
    public string RegistryNumber {  get; set; } = string.Empty;
}
