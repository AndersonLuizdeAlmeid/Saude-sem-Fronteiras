using Dapper;
using SaudeSemFronteiras.Application.Prescriptions.Domain;
using SaudeSemFronteiras.Application.Prescriptions.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Prescriptions.Queries;
public class PrescriptionQueries(IDatabaseFactory databaseFactory) : IPrescriptionQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<PrescriptionDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           description as Description,
                           document_id as DocumentId
                      FROM prescriptions ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<PrescriptionDto>(command);
    }

    public async Task<Prescription?> GetByID(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           description as Description,
                           document_id as DocumentId
                      from prescriptions
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Prescription>(command);
    }

    public async Task<PrescriptionDto?> GetPrescriptionByDocumentIdQuery(long documentId, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           description as Description,
                           document_id as DocumentId
                      from prescriptions
                     where document_id = @documentId";

        var command = new CommandDefinition(sql, new { documentId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<PrescriptionDto>(command);
    }

    public async Task<long?> GetPrescriptionIdByDocumentIdQuery(long documentId, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id
                      from prescriptions
                     where document_id = @documentId";

        var command = new CommandDefinition(sql, new { documentId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<long>(command);
    }

    public async Task<IEnumerable<PrescriptionShowDto>> GetPrescriptionShowByDocumentIdQuery(long documentId, CancellationToken cancellationToken)
    {
        var sql = @"select users_patient.name as NamePatient, 
	                       addresses.street as Street, 
	                       addresses.number as Number, 
	                       addresses.district as District,
	                       medicines.description as Description, 
	                       medicines.quantity as Quantity, 
	                       medicines.dosage as Dosage, 
	                       medicines.observation as Observation,
	                       documents.date_document as Date,
	                       cities.description as City,
	                       states.description as State,
	                       users_doctor.name as NameDoctor,
	                       doctors.registry_number as RegistryNumber
                      from documents inner join appointments
  						                     on documents.appointment_id = appointments.id 
  				                     inner join patients 
  						                     on patients.id = appointments.patient_id
  				                     inner join doctors
  				 		                     on doctors.id = appointments.doctor_id
  				                     inner join users users_doctor
  				 	 	                     on users_doctor.id = doctors.user_id 
  				                     inner join users users_patient
  				 		                     on users_patient.id = patients.user_id
  				                     inner join prescriptions 
  				 		                     on prescriptions.document_id = documents.id
  				 		             INNER JOIN medicines
  				 		             		 ON prescriptions.id = medicines.prescription_id
  				 		             inner join addresses 
  				 		             		 on addresses.user_id = users_patient.id
  				 		             inner join cities 
  				 		             		 on cities.id = addresses.city_id 
  				 		             inner join states 
  				 		              		 on states.id = cities.state_id 
                     where prescriptions.document_id = @documentId ";

        var command = new CommandDefinition(sql, new { documentId } ,transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<PrescriptionShowDto>(command);
    }
}
