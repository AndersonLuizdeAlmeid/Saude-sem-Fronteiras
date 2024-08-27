namespace SaudeSemFronteiras.Application.Addresses.Domain;
public class Address
{
    public long Id {  get; private set; }
    public string District { get; private set; } = string.Empty;
    public string Street {  get; private set; } = string.Empty;
    public string Number {  get; private set; } = string.Empty;
    public string Complement {  get; private set; } = string.Empty;
    public long CityId { get; private set; }
    public long UserId { get; private set; }

    public Address(long id, string district, string street, string number, string complement, long cityId, long userId)
    {
        Id = id;
        District = district;
        Street = street;
        Number = number;
        Complement = complement;
        CityId = cityId;
        UserId = userId;
    }

    public static Address Create(string district, string street, string number, string complement, long cityId, long userId) =>
        new(0, district, street, number, complement, cityId, userId);

    public void Update(string district, string street, string number, string complement, long cityId, long userId)
    {
        District = district;
        Street = street;
        Number = number;
        Complement = complement;
        CityId = cityId;
        UserId = userId;
    }
}
