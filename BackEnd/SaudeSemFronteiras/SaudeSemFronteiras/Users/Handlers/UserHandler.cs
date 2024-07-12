using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Users.Commands;
using SaudeSemFronteiras.Application.Users.Domain;
using SaudeSemFronteiras.Application.Users.Repository;

namespace SaudeSemFronteiras.Application.Users.Handlers;
public class UserHandler : IRequestHandler<CreateUserCommand, Result>,
                           IRequestHandler<ChangeUserCommand, Result>
{
    private readonly IUserRepository _userRepository;

    public UserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var user = User.Create(request.Name, request.CPF, request.MotherName, request.DateBirth, DateTime.Now, request.Language);

        await _userRepository.Insert(user, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(ChangeUserCommand request, CancellationToken cancellationToken)
    {
        //TODO Ver possibilidade de bloquear quando tiver consultas abertas.
        var user = await _userRepository.GetByID(request.Id, cancellationToken);
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
