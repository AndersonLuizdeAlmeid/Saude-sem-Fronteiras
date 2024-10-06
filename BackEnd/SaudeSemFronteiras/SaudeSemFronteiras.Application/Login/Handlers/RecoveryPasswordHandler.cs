using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Login.Commands;
using SaudeSemFronteiras.Application.Login.Domain;
using SaudeSemFronteiras.Application.Login.Queries;
using SaudeSemFronteiras.Application.Login.Services;

namespace SaudeSemFronteiras.Application.Login.Handlers;
public class RecoveryPasswordHandler : IRequestHandler<RecoveryPasswordCommand, Result>
{
    private readonly ICredentialsQueries _credentialsQueries;

    public RecoveryPasswordHandler(ICredentialsQueries credentialsQueries)
    {
        _credentialsQueries = credentialsQueries;
    }

    public async Task<Result> Handle(RecoveryPasswordCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        var validationEmail = _credentialsQueries.GetIfEmailExists(request.Email, cancellationToken);

        if (await validationEmail < 0)
            return Result.Failure("Email não cadastrado.");

        CredentialsService.SendConfirmationEmail(request.Email, cancellationToken);

        return Result.Success();
    }
}
