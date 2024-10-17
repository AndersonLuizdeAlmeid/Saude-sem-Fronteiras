using Dapper;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Database.Repository;
public class DatabaseRepository : IDatabaseRepository
{
    public IDatabaseFactory LocalDatabase { get; }


    public DatabaseRepository(IDatabaseFactory databaseFactory)
    {
        LocalDatabase = databaseFactory;
    }

    public async Task CreateCountriesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        countries (
                            id SERIAL PRIMARY KEY NOT NULL,
                            description VARCHAR(255) NOT NULL
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateStatesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        states (
                            id SERIAL PRIMARY KEY NOT NULL,
                            description VARCHAR(255) NOT NULL,
                            uf VARCHAR(5) NOT NULL,
                            country_id BIGINT,
                            FOREIGN KEY (country_id) REFERENCES countries(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateCitiesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        cities (
                            id SERIAL PRIMARY KEY NOT NULL,
                            description VARCHAR(255) NOT NULL,
                            cep VARCHAR(25) NOT NULL,
                            state_id BIGINT,
                            FOREIGN KEY (state_id) REFERENCES states(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateCredentialsTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        credentials (
                            id SERIAL PRIMARY KEY NOT NULL,
                            email VARCHAR(255) NOT NULL,
                            password VARCHAR(255) NOT NULL
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateUsersTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        users (
                            id SERIAL PRIMARY KEY NOT NULL,
                            name VARCHAR(255) NOT NULL,
                            cpf VARCHAR(14) NOT NULL,
                            mother_name VARCHAR(255) NOT NULL,
                            date_birth TIMESTAMP NOT NULL,
                            date_of_creation TIMESTAMP NOT NULL,
                            gender VARCHAR(50) NOT NULL,
                            language VARCHAR(50) NOT NULL,
                            is_active BOOLEAN NOT NULL,
                            phone VARCHAR(25) NOT NULL,
                            credentials_id BIGINT,
                            FOREIGN KEY (credentials_id) REFERENCES credentials(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateAddressesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        addresses (
                            id SERIAL PRIMARY KEY NOT NULL,
                            district VARCHAR(255) NOT NULL,
                            street VARCHAR(255) NOT NULL,
                            number VARCHAR(10) NOT NULL,
                            complement VARCHAR(255),
                            city_id BIGINT,
                            user_id BIGINT,
                            FOREIGN KEY (city_id) REFERENCES cities(id),
                            FOREIGN KEY (user_id) REFERENCES users(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreatePatientsTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        patients (
                            id SERIAL PRIMARY KEY NOT NULL,
                            blood_type VARCHAR(14) NOT NULL,
                            allergies VARCHAR(255),
                            medical_condition VARCHAR(255) NOT NULL,
                            previous_surgeries VARCHAR(255),
                            medicines VARCHAR(255),
                            emergency_number VARCHAR(25) NOT NULL,
                            user_id BIGINT,
                            FOREIGN KEY (user_id) REFERENCES users(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateDoctorsTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        doctors (
                            id SERIAL PRIMARY KEY NOT NULL,
                            registry_number VARCHAR(25) NOT NULL,
                            initial_hour VARCHAR(14) NOT NULL,
                            final_hour VARCHAR(14) NOT NULL,
                            consultation_price VARCHAR(25) NOT NULL,
                            days VARCHAR(14) NOT NULL,
                            user_id BIGINT,
                            FOREIGN KEY (user_id) REFERENCES users(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateSpecialitiesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        specialities (
                            id SERIAL PRIMARY KEY NOT NULL,
                            description VARCHAR(255) NOT NULL,
                            is_active VARCHAR(14) NOT NULL,
                            doctor_id BIGINT NOT NULL,
                            FOREIGN KEY (doctor_id) REFERENCES doctors(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateAppointmentsTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        appointments (
                            id SERIAL PRIMARY KEY NOT NULL,
                            date TIMESTAMP NOT NULL,
                            duration VARCHAR(8),
                            patient_id BIGINT,
                            doctor_id BIGINT,
                            FOREIGN KEY (patient_id) REFERENCES patients(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateInvoicesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        invoices (
                            id SERIAL PRIMARY KEY NOT NULL,
                            issuance_date TIMESTAMP NOT NULL,
                            due_date TIMESTAMP NOT NULL,
                            value DECIMAL NOT NULL,
                            status SMALLINT NOT NULL,
                            description VARCHAR(255) NOT NULL,
                            agency VARCHAR(255) NOT NULL,
                            account VARCHAR(255) NOT NULL,
                            digit VARCHAR(255) NOT NULL,
                            standard_wallet VARCHAR(255) NOT NULL,
                            patient_id BIGINT,
                            doctor_id BIGINT,
                            appointment_id BIGINT,
                            FOREIGN KEY (appointment_id) REFERENCES appointments(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateDocumentsTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        documents (
                            id SERIAL PRIMARY KEY NOT NULL,
                            type_document VARCHAR(15) NOT NULL,
                            date_document TIMESTAMP NOT NULL,
                            appointment_id BIGINT,
                            FOREIGN KEY (appointment_id) REFERENCES appointments(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateExamsTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        exams (
                            id SERIAL PRIMARY KEY NOT NULL,
                            description VARCHAR(255) NOT NULL,
                            justification VARCHAR(255) NOT NULL,
                            date_exam TIMESTAMP,
                            local_exam VARCHAR(255) NOT NULL,
                            results VARCHAR(255),
                            comments VARCHAR(255),
                            document_id BIGINT,
                            FOREIGN KEY (document_id) REFERENCES documents(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreatePrescriptionsTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        prescriptions (
                            id SERIAL PRIMARY KEY NOT NULL,
                            description VARCHAR(2550) NOT NULL,
                            document_id BIGINT,
                            FOREIGN KEY (document_id) REFERENCES documents(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateMedicinesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        medicines (
                            id SERIAL PRIMARY KEY NOT NULL,
                            description VARCHAR(2550) NOT NULL,
                            quantity VARCHAR(2550) NOT NULL,
                            dosage VARCHAR(2550) NOT NULL,
                            observation VARCHAR(2550) NOT NULL,
                            prescription_id SERIAL NOT NULL,
                            FOREIGN KEY (prescription_id) REFERENCES prescriptions(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateCertificatesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        certificates (
                            id SERIAL PRIMARY KEY NOT NULL,
                            name VARCHAR(255) NOT NULL,
                            cpf VARCHAR(255) NOT NULL,
                            days SMALLINT NOT NULL,
                            cid BIGINT,
                            document_id BIGINT,
                            FOREIGN KEY (document_id) REFERENCES documents(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateScheduledTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        scheduled (
                            id SERIAL PRIMARY KEY NOT NULL,
                            price DECIMAL NOT NULL,
                            scheduled_date TIMESTAMP NOT NULL,
                            status SMALLINT NOT NULL,
                            appointment_id BIGINT,
                            FOREIGN KEY (appointment_id) REFERENCES appointments(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateEmergenciesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        emergencies (
                            id SERIAL PRIMARY KEY NOT NULL,
                            price DECIMAL NOT NULL,
                            wait_time VARCHAR(255),
                            status SMALLINT NOT NULL,
                            appointment_id BIGINT,
                            FOREIGN KEY (appointment_id) REFERENCES appointments(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateScreeningsTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        screenings (
                            id SERIAL PRIMARY KEY NOT NULL,
                            symptons VARCHAR(255) NOT NULL,
                            date_symptons VARCHAR(255) NOT NULL,
                            continuos_medicine VARCHAR(255),
                            allergies VARCHAR(255),
                            observations VARCHAR(255),
                            emergency_id BIGINT,
                            FOREIGN KEY (emergency_id) REFERENCES emergencies(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }
}
