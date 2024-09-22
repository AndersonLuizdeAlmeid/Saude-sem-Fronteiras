using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Doctors.Queries;
using SaudeSemFronteiras.Application.Patients.Queries;
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
    private readonly IPatientQueries _patientQueries;
    private readonly IDoctorQueries _doctorQueries;

    public UserHandler(IUserRepository userRepository, IUserQueries userQueries, IPatientQueries patientQueries, IDoctorQueries doctorQueries)
    {
        _userRepository = userRepository;
        _userQueries = userQueries;
        _patientQueries = patientQueries;
        _doctorQueries = doctorQueries;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var user = User.Create(request.Name, request.CPF, request.MotherName, request.DateBirth, DateTime.Now, request.Gender, request.Language, true, request.Phone, request.CredentialsId);

        await _userRepository.Insert(user, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(ChangeUserCommand request, CancellationToken cancellationToken)
    {
        //TODO Ver possibilidade de bloquear quando tiver consultas abertas.
        var userDto = await _userQueries.GetByID(request.Id, cancellationToken);
        if (userDto == null)
            return Result.Failure("Usuário não encontrado");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;
        User user = new User(userDto.Id, request.Name, request.CPF, request.MotherName, request.DateBirth, request.Gender, request.Language, true, request.Phone);

        user.Update(request.Name, request.CPF, request.MotherName, request.DateBirth, request.Gender, request.Language, request.IsActive, request.Phone);

        await _userRepository.Update(user, cancellationToken);

        return Result.Success();
    }
}
