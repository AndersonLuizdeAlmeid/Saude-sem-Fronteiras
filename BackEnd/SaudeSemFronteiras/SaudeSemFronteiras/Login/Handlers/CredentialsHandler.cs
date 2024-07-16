using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Login.Commands;
using SaudeSemFronteiras.Application.Login.Domain;
using SaudeSemFronteiras.Application.Login.Repository;

namespace SaudeSemFronteiras.Application.Login.Handlers;
public class CredentialsHandler : IRequestHandler<CreateCredentialsCommand, Result>,
                                  IRequestHandler<ChangeCredentialsCommand, Result>
{
    private readonly ICredentialsRepository _credentialsRepository;

    public CredentialsHandler(ICredentialsRepository credentialsRepository)
    {
        _credentialsRepository = credentialsRepository;
    }

    public async Task<Result> Handle(CreateCredentialsCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var credentials = Credentials.Create(request.Email, request.Password);

        await _credentialsRepository.Insert(credentials, cancellationToken);

        return Result.Success();
    }
    public async Task<Result> Handle(ChangeCredentialsCommand request, CancellationToken cancellationToken)
    {
        var credentials = await _credentialsRepository.GetById(request.Id, cancellationToken);
        if (credentials == null)
            return Result.Failure("Usuário não cadastrado");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        credentials.Update(request.Email, request.Password);

        await _credentialsRepository.Update(credentials, cancellationToken);

        return Result.Success();
    }
}

