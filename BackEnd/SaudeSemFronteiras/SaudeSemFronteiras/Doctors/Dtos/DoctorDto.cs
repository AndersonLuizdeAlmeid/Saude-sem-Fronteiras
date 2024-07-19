namespace SaudeSemFronteiras.Application.Doctors.Dtos;
public class DoctorDto
{
    public long Id { get;  set; }
    public string RegistryNumber { get;  set; } = string.Empty;
    public string AvaibalityHours { get;  set; } = string.Empty;
    public decimal ConsultationPrince { get;  set; }
    public long IdUser { get;  set; }
    public long IdAppointment { get;  set; }
}
