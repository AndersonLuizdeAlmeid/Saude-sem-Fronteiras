namespace SaudeSemFronteiras.Application.Addresses.Domain;
public class Address
{
    public long Id {  get; private set; }
    public string District { get; private set; } = string.Empty;
    public string Street {  get; private set; } = string.Empty;
    public string Number {  get; private set; } = string.Empty;
    public string Complement {  get; private set; } = string.Empty;
    public long CityId { get; private set; }

    public Address(long id, string district, string street, string number, string complement, long cityId)
    {
        Id = id;
        District = district;
        Street = street;
        Number = number;
        Complement = complement;
        CityId = cityId;
    }

    public static Address Create(string district, string street, string number, string complement, long cityId) =>
        new(0, district, street, number, complement, cityId);

    public void Update(string district, string street, string number, string complement, long cityId)
    {
        District = district;
        Street = street;
        Number = number;
        Complement = complement;
        CityId = cityId;
    }
}
