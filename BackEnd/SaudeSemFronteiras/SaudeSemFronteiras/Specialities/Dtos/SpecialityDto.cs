namespace SaudeSemFronteiras.Application.Specialities.Dtos;

public class SpecialityDto
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
