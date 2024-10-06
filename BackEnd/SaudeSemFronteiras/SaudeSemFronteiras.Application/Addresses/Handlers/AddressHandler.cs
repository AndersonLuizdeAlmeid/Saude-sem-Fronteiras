using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SaudeSemFronteiras.Application.Addresses.Commands;
using SaudeSemFronteiras.Application.Addresses.Domain;
using SaudeSemFronteiras.Application.Addresses.Queries;
using SaudeSemFronteiras.Application.Addresses.Repositories;
using SaudeSemFronteiras.Application.Users.Queries;

namespace SaudeSemFronteiras.Application.Addresses.Handlers;
public class AddressHandler : IRequestHandler<CreateAddressCommand, Result>,
                              IRequestHandler<ChangeAddressCommand, Result>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IAddressQueries _addressQueries;
    private readonly IUserQueries _userQueries;

    public AddressHandler(IAddressRepository addressRepository, IAddressQueries addressQueries, IUserQueries userQueries)
    {
        _addressRepository = addressRepository;
        _addressQueries = addressQueries;
        _userQueries = userQueries;
    }

    public async Task<Result> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var address = Address.Create(request.District, request.Street, request.Number, request.Complement, request.CityId, request.UserId);

        await _addressRepository.Insert(address, cancellationToken);

        return Result.Success();
    }
    public async Task<Result> Handle(ChangeAddressCommand request, CancellationToken cancellationToken)
    {
        var addressDto = await _addressQueries.GetByUserId(request.UserId, cancellationToken);
        if (addressDto == null)
            return Result.Failure("Endereço não encontrado");

        var validationResult = request.Validation();
        if (validationResult.IsFailure)
            return validationResult;

        var address = new Address(addressDto.Id, request.District, request.Street, request.Number, request.Complement, request.CityId, request.UserId);

        address.Update(request.District, request.Street, request.Number, request.Complement, request.CityId, request.UserId);

        await _addressRepository.Update(address, cancellationToken);

        return Result.Success();
    }
}
