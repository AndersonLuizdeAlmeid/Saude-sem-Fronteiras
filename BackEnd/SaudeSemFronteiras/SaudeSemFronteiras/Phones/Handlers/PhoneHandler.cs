using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Phones.Repository;
using SaudeSemFronteiras.Application.Phones.Commands;
using SaudeSemFronteiras.Application.Phones.Domain;

namespace SaudeSemFronteiras.Application.Phones.Handlers;
public class PhoneHandler : IRequestHandler<CreatePhoneCommand, Result>,
                            IRequestHandler<ChangePhoneCommand, Result>
{
    private readonly IPhoneRepository _phoneRepository;

    public PhoneHandler(IPhoneRepository phoneRepository)
    {
        _phoneRepository = phoneRepository;
    }

    public async Task<Result> Handle(CreatePhoneCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var phone = Phone.Create(request.Number, request.UserId);

        await _phoneRepository.Insert(phone, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Handle(ChangePhoneCommand request, CancellationToken cancellationToken)
    {
        var phone = await _phoneRepository.GetById(request.Id, cancellationToken);
        if (phone == null)
            return Result.Failure("Telefone não encontrado");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        phone.Update(request.Number, request.UserId);

        await _phoneRepository.Update(phone, cancellationToken);

        return Result.Success();
    }
}
