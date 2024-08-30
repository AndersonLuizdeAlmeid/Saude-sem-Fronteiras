using SaudeSemFronteiras.Application.Phones.Domain;
using SaudeSemFronteiras.Application.Phones.Dtos;

namespace SaudeSemFronteiras.Application.Phones.Queries;

public interface IPhoneQueries
{
    Task<IEnumerable<PhoneDto>> GetAll(CancellationToken cancellationToken);
    Task<IEnumerable<PhoneDataDto>> GetAllPhonesByUserId(long userId, CancellationToken cancellationToken);
    Task<Phone?> GetById(long iD, CancellationToken cancellationToken);
}
