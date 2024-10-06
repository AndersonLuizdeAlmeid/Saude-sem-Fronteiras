namespace SaudeSemFronteiras.Application.Doctors.Dtos;
public class DoctorDto
{
    public long Id { get; set; }
    public string RegistryNumber { get; set; } = string.Empty;
    public string InitialHour { get; set; } = string.Empty;
    public string FinalHour { get; set; } = string.Empty;
    public decimal ConsultationPrice { get; set; }
    public string Days { get; set; } = string.Empty;
    public long UserId { get;  set; }
}
