﻿using SaudeSemFronteiras.Application.Doctors.Domain;
using SaudeSemFronteiras.Application.Doctors.Dtos;

namespace SaudeSemFronteiras.Application.Doctors.Queries;
public interface IDoctorQueries
{
    Task<IEnumerable<DoctorDto>> GetAll(CancellationToken cancellationToken);
    Task<Doctor?> GetById(long iD, CancellationToken cancellationToken);
}
