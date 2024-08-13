namespace SaudeSemFronteiras.Application.Appointments.Dtos;
public class AppointmentDto
{
    public long Id { get; set; }
    public DateTime Time { get; set; }
    public decimal Duration { get; set; }
    public long DoctorId { get; set; }
    public long PatientId { get; set; }
}
