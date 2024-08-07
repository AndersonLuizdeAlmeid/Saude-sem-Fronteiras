using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Users.Commands;
using SaudeSemFronteiras.Application.Users.Domain;
using SaudeSemFronteiras.Application.Users.Queries;
using SaudeSemFronteiras.Application.Users.Repository;

namespace SaudeSemFronteiras.Application.Users.Handlers;
public class UserHandler : IRequestHandler<CreateUserCommand, Result>,
                           IRequestHandler<ChangeUserCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserQueries _userQueries;

    public UserHandler(IUserRepository userRepository, IUserQueries userQueries)
    {
        _userRepository = userRepository;
        _userQueries = userQueries;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var user = User.Create(request.Name, request.CPF, request.MotherName, request.DateBirth, DateTime.Now, request.Language, true);

        await _userRepository.Insert(user, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(ChangeUserCommand request, CancellationToken cancellationToken)
    {
        //TODO Ver possibilidade de bloquear quando tiver consultas abertas.
        var user = await _userQueries.GetByID(request.Id, cancellationToken);
        if (user == null)
            return Result.Failure("Usuário não encontrado");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        user.Update(request.Name, request.CPF, request.MotherName, request.DateBirth, request.Language, request.IsActive);

        await _userRepository.Update(user, cancellationToken);

        return Result.Success();
    }
}
