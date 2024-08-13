using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Login.Commands;
using SaudeSemFronteiras.Application.Login.Domain;
using SaudeSemFronteiras.Application.Login.Queries;
using SaudeSemFronteiras.Application.Login.Repository;

namespace SaudeSemFronteiras.Application.Login.Handlers;
public class CredentialsHandler : IRequestHandler<CreateCredentialsCommand, Result>,
                                  IRequestHandler<ChangeCredentialsCommand, Result>
{
    private readonly ICredentialsRepository _credentialsRepository;
    private readonly ICredentialsQueries _credentialsQueries;

    public CredentialsHandler(ICredentialsRepository credentialsRepository, ICredentialsQueries credentialsQueries)
    {
        _credentialsRepository = credentialsRepository;
        _credentialsQueries = credentialsQueries;
    }

    public async Task<Result> Handle(CreateCredentialsCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var validateEmail = _credentialsQueries.GetIfEmailExists(request.Email, cancellationToken);
        if (validateEmail.Result == 0)
            return Result.Failure("Email já existe");

        var credentials = Credentials.Create(request.Email, request.Password, request.UserId);

        await _credentialsRepository.Insert(credentials, cancellationToken);

        return Result.Success();
    }
    public async Task<Result> Handle(ChangeCredentialsCommand request, CancellationToken cancellationToken)
    {
        var credentials = await _credentialsQueries.GetById(request.Id, cancellationToken);
        if (credentials == null)
            return Result.Failure("Usuário não cadastrado");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        credentials.Update(request.Email, request.Password, request.UserId);

        await _credentialsRepository.Update(credentials, cancellationToken);

        return Result.Success();
    }
}

