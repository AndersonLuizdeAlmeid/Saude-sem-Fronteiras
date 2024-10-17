namespace SaudeSemFronteiras.Application.States.Dtos;
public class StateDto
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Uf {  get; set; } = string.Empty;
    public long CountryId { get; set; }
}
