using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Authentications.Commands;
using SaudeSemFronteiras.Application.JwtToken.Services;
using SaudeSemFronteiras.Application.Login.Queries;
using SaudeSemFronteiras.Application.Users.Dtos;
using SaudeSemFronteiras.Application.Users.Queries;
using System.Text.RegularExpressions;

namespace SaudeSemFronteiras.Application.Authentications.Handlers;

public class AuthenticationsHandler(ICredentialsQueries _credentialsQueries, IUserQueries _userQueries) : IRequestHandler<AuthenticationCommand, Result<string>>
{
    const string RegexEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    public async Task<Result<string>> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
    {
        if (!Regex.IsMatch(request.Email, RegexEmail))
            return Result.Failure<string>("O email está incorreto.");

        var credentials = await _credentialsQueries.GetByEmailAndPassword(request.Email, request.Password, cancellationToken);

        var user = await _userQueries.GetByID(credentials.Id, cancellationToken);
            
        if (user == null)
            return Result.Failure<string>("Email ou senha incorreto.");

        if(!user.IsActive)
            return Result.Failure<string>("O usuário está inativo.");

        UserDto userDto = new();
        userDto.Name = user.Name;
        userDto.CPF = user.CPF;
        userDto.MotherName = user.MotherName;
        userDto.DateBirth = user.DateBirth;
        userDto.Language = user.Language;
        userDto.IsActive = user.IsActive;

        var token = TokenService.GenerateCustomToken(userDto);

        return Result.Success(token);
    }
}
