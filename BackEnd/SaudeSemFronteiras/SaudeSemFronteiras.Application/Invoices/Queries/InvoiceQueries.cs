using Dapper;
using SaudeSemFronteiras.Application.Invoices.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Invoices.Queries;

public class InvoiceQueries(IDatabaseFactory databaseFactory) : IInvoiceQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<InvoiceDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           issuance_date as IssuanceDate,
                           due_date as DueDate, 
                           value as Value,
                           status as Status,
                           description as Description,
                           agency as Agency,
                           account as Account,
                           digit as Digit,
                           standard_wallet as StandardWallet,
                           patient_id as PatientId,
                           doctor_id as DoctorId,
                           appointment_id as AppointmentId
                      FROM invoices "
        ;
        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<InvoiceDto>(command);
    }

    public async Task<InvoiceDto?> GetByID(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           issuance_date as IssuanceDate,
                           due_date as DueDate, 
                           value as Value,
                           status as Status,
                           description as Description,
                           agency as Agency,
                           account as Account,
                           digit as Digit,
                           standard_wallet as StandardWallet,
                           patient_id as PatientId,
                           doctor_id as DoctorId,
                           appointment_id as AppointmentId
                      from invoices
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<InvoiceDto>(command);
    }

    public async Task<IEnumerable<InvoiceShowDto?>> GetInvoiceByDoctorIdQuery(long doctorId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT invoices.id as Id,
                           users.name as Name, 
                           invoices.status as Status, 
                           TO_CHAR(invoices.due_date , 'YYYY-MM-DD HH24:MI:SS') as Date
                      FROM invoices INNER JOIN appointments 
 					 	                     ON invoices.appointment_id  = appointments.id
 				                     INNER JOIN patients 
 					 	                     ON patients.id = appointments.patient_id 
 				                     INNER JOIN users
 					 	                     ON users.id = patients.user_id
                     WHERE appointments.doctor_id = @doctorId
                     ORDER BY Date ";

        var command = new CommandDefinition(sql, new { doctorId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<InvoiceShowDto>(command);
    }

    public async Task<IEnumerable<InvoiceShowDto?>> GetInvoiceByPatientQuery(long patientId, CancellationToken cancellationToken)
    {
        var sql = @"SELECT invoices.id as Id,
                           users.name as Name, 
                           invoices.status as Status, 
                           TO_CHAR(invoices.due_date , 'YYYY-MM-DD HH24:MI:SS') as Date
                      FROM invoices INNER JOIN appointments 
 					 	                     ON invoices.appointment_id  = appointments.id
 				                     INNER JOIN patients 
 					 	                     ON patients.id = appointments.patient_id 
 				                     INNER JOIN users
 					 	                     ON users.id = patients.user_id
                     WHERE appointments.patient_id = @patientId
                     ORDER BY Date ";

        var command = new CommandDefinition(sql, new { patientId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<InvoiceShowDto>(command);
    }

    public async Task<InvoiceCompleteDto?> GetDataToBoleto(long invoiceId, CancellationToken cancellationToken)
    {
        var sql = @"select invoices.id as Id,
	                       invoices.issuance_date as IssuanceDate,
	                       invoices.due_date as DueDate,
	                       invoices.value as Value,
	                       invoices.status as Status,
	                       invoices.description as Description,
	                       invoices.agency as Agency,
	                       invoices.account as Account,
	                       invoices.digit as Digit,
	                       invoices.standard_wallet as StandardWallet,
	                       users_patient.cpf as CpfPayer,
	                       users_patient.name as NamePayer,
                           patient_addresses.street as StreetPayer,
	                       patient_addresses.number as NumberPayer,
	                       patient_addresses.district as DistrictPayer,
	                       states_patient.uf as UfPayer,
	                       cities_patient.cep as CepPayer,
	                       cities_patient.description as CityDescriptionPayer,
	                       patient_addresses.complement as ComplementPayer,
	                       users_doctor.cpf as CpfReceiver,
	                       users_doctor.name as NameReceiver,
                           doctor_addresses.street as StreetReceiver,
	                       doctor_addresses.number as NumberReceiver,
	                       doctor_addresses.district as DistrictReceiver,
	                       states_doctor.uf as UfReceiver,
	                       cities_doctor.cep as CepReceiver,
	                       cities_doctor.description as CityDescriptionReceiver,
	                       doctor_addresses.complement as ComplementReceiver
                      from invoices inner join patients 
  						                    on invoices.patient_id = patients.id
  				                    inner join users users_patient
  						                    on users_patient.id = patients.user_id
  				                    inner join addresses patient_addresses
  						                    on patient_addresses.user_id = users_patient.id
  				                    inner join cities cities_patient
  						                    on cities_patient.id = patient_addresses.city_id 
  						            inner join states states_patient
  						            		on states_patient.id = cities_patient.state_id
  				                    inner join doctors 
  						                    on doctors.id = invoices.doctor_id 
  				                    inner join users users_doctor
  						                    on users_doctor.id = doctors.user_id 
                                    inner join addresses doctor_addresses
  						                    on doctor_addresses.user_id = users_doctor.id
  				                    inner join cities cities_doctor
  						                    on cities_doctor.id = doctor_addresses.city_id
  						            INNER JOIN states states_doctor
  						            		ON states_doctor.id = cities_doctor.id 
                     where invoices.id = @invoiceId";

        var command = new CommandDefinition(sql, new { invoiceId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstAsync<InvoiceCompleteDto>(command);
    }
}
