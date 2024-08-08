using Dapper;
using SaudeSemFronteiras.Application.Patients.Domain;
using SaudeSemFronteiras.Application.Patients.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Patients.Queries;
public class PatientQueries(IDatabaseFactory databaseFactory) : IPatientQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<PatientDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           blood_type as BloodType, 
                           allergies as Allergies,
                           medical_condition as MedicalCondition,
                           previous_surgeries as PreviousSurgeries,
                           medicines as Medicines,
                           emergency_number as EmergencyNumber,
                           user_id as UserId
                      FROM patients ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<PatientDto>(command);
    }

    public async Task<Patient?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           blood_type as BloodType, 
                           allergies as Allergies,
                           medical_condition as MedicalCondition,
                           previous_surgeries as PreviousSurgeries,
                           medicines as Medicines,
                           emergency_number as EmergencyNumber,
                           user_id as UserId
                      from patients
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Patient>(command);
    }
}
