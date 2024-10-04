namespace SaudeSemFronteiras.Application.Exams.Dtos;
public class ExamDtoShow
{
    public string NamePatient {  get; set; } = string.Empty;
    public short Age { get; set; }
    public string Gender { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Justification { get; set; } = string.Empty;
    public string NameDoctor { get; set; } = string.Empty;
    public string RegistryNumber { get; set; } = string.Empty;
}