namespace SaudeSemFronteiras.Application.Cities.Dtos;
public class CityDto
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public long StateId { get; set; }
}
