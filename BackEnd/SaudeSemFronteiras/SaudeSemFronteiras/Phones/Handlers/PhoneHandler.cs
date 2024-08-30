using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Phones.Repository;
using SaudeSemFronteiras.Application.Phones.Commands;
using SaudeSemFronteiras.Application.Phones.Domain;
using SaudeSemFronteiras.Application.Phones.Queries;

namespace SaudeSemFronteiras.Application.Phones.Handlers;
public class PhoneHandler : IRequestHandler<CreatePhoneCommand, Result>,
                            IRequestHandler<ChangePhoneCommand, Result>,
                            IRequestHandler<DeletePhoneCommand, Result>
{
    private readonly IPhoneRepository _phoneRepository;
    private readonly IPhoneQueries _phoneQueries;

    public PhoneHandler(IPhoneRepository phoneRepository, IPhoneQueries phoneQueries)
    {
        _phoneRepository = phoneRepository;
        _phoneQueries = phoneQueries;
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
        var phone = await _phoneQueries.GetById(request.Id, cancellationToken);
        if (phone == null)
            return Result.Failure("Telefone não encontrado");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        phone.Update(request.Number, request.UserId);

        await _phoneRepository.Update(phone, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(DeletePhoneCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        await _phoneRepository.Delete(request.Id, cancellationToken);

        return Result.Success();
    }
}
