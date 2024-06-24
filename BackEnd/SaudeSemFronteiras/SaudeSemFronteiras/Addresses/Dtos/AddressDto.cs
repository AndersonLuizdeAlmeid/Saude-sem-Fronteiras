namespace SaudeSemFronteiras.Application.Addresses.Dtos;
public class AddressDto
{
    public long Id { get; set; }
    public string District { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Complement { get; set; } = string.Empty;
    public long CityId { get; set; }
}
