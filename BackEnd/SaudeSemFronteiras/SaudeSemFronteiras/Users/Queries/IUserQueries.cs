﻿using SaudeSemFronteiras.Application.Users.Domain;
using SaudeSemFronteiras.Application.Users.Dtos;

namespace SaudeSemFronteiras.Application.Users.Queries;
public interface IUserQueries
{
    Task<IEnumerable<UserDto>>GetAll(CancellationToken cancellationToken);
    Task<User?> GetByID(long iD, CancellationToken cancellationToken);
}