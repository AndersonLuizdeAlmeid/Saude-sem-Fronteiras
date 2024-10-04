using Dapper;
using SaudeSemFronteiras.Application.Exams.Domain;
using SaudeSemFronteiras.Application.Exams.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Exams.Queries;
public class ExamQueries(IDatabaseFactory databaseFactory) : IExamQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<ExamDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           description as Description, 
                           date_exam as DateExam,
                           local_exam as LocalExam,
                           results as Results,
                           comments as Comments,
                           document_id as DocumentId
                      FROM exams ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<ExamDto>(command);
    }

    public async Task<Exam?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           description as Description, 
                           justification as Justification,
                           date_exam as DateExam,
                           local_exam as LocalExam,
                           results as Results,
                           comments as Comments,
                           document_id as DocumentId
                      from exams
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Exam>(command);
    }

    public async Task<ExamDtoShow?> GetExamByDocumentIdQuery(long documentId, CancellationToken cancellationToken)
    {
        var sql = @"select users_patient.name as NamePatient, 
	                       EXTRACT(YEAR FROM AGE(users_patient.date_birth)) as Age, 
	                       users_patient.gender as Gender, 
	                       documents.date_document as Date, 
	                       exams.description as Description, 
	                       exams.justification as Justification,
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
  				                     inner join exams 
  				 		                     on exams.document_id = documents.id 
                    where documents.id = @documentId";

        var command = new CommandDefinition(sql, new { documentId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<ExamDtoShow>(command);
    }
}
