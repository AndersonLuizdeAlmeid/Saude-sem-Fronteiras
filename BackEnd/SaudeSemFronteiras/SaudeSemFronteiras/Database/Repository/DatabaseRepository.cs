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
                            language VARCHAR(50) NOT NULL,
                            is_active BOOLEAN NOT NULL,
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

    public async Task CreatePhonesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        phones (
                            id SERIAL PRIMARY KEY NOT NULL,
                            number VARCHAR(25) NOT NULL,
                            user_id BIGINT,
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
                            avaibality_hours VARCHAR(14) NOT NULL,
                            consultation_prince VARCHAR(25) NOT NULL,
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
                            doctor_id BIGINT,
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
                            FOREIGN KEY (patient_id) REFERENCES patients(id),
                            FOREIGN KEY (doctor_id) REFERENCES doctors(id)
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
                            description VARCHAR(255) NOT NULL,
                            status VARCHAR(25) NOT NULL,
                            value VARCHAR(25) NOT NULL,
                            tax VARCHAR(25),
                            discount VARCHAR(25),
                            terms VARCHAR(255),
                            appointment_id BIGINT,
                            FOREIGN KEY (appointment_id) REFERENCES appointments(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateChatsTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        chats (
                            id SERIAL PRIMARY KEY NOT NULL,
                            chat_date TIMESTAMP NOT NULL,
                            status VARCHAR(25) NOT NULL,
                            appointment_id BIGINT,
                            FOREIGN KEY (appointment_id) REFERENCES appointments(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateMessagesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        messages (
                            id SERIAL PRIMARY KEY NOT NULL,
                            message_date TIMESTAMP NOT NULL,
                            description VARCHAR(255) NOT NULL,
                            chat_id BIGINT,
                            FOREIGN KEY (chat_id) REFERENCES chats(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateDocumentsTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        documents (
                            id SERIAL PRIMARY KEY NOT NULL,
                            description VARCHAR(255) NOT NULL,
                            type_document VARCHAR(15) NOT NULL,
                            date_document TIMESTAMP NOT NULL,
                            digitally_signed VARCHAR(255),
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
                            title VARCHAR(255) NOT NULL,
                            description VARCHAR(255) NOT NULL,
                            date_exam TIMESTAMP NOT NULL,
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
                            issuance_date TIMESTAMP NOT NULL,
                            title VARCHAR(255) NOT NULL,
                            description VARCHAR(255) NOT NULL,
                            instructions VARCHAR(255) NOT NULL,
                            final_date TIMESTAMP,
                            observations VARCHAR(255),
                            prescription_validate TIMESTAMP NOT NULL,
                            document_id BIGINT,
                            FOREIGN KEY (document_id) REFERENCES documents(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task CreateCertificatesTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS 
                        certificates (
                            id SERIAL PRIMARY KEY NOT NULL,
                            issuance_date TIMESTAMP NOT NULL,
                            title VARCHAR(255) NOT NULL,
                            description VARCHAR(255) NOT NULL,
                            start_date TIMESTAMP NOT NULL,
                            final_date TIMESTAMP NOT NULL,
                            observations VARCHAR(255),
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
                            value VARCHAR(25) NOT NULL,
                            scheduled_date TIMESTAMP NOT NULL,
                            is_active VARCHAR(14) NOT NULL,
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
                            value VARCHAR(25) NOT NULL,
                            wait_time TIMESTAMP,
                            is_active VARCHAR(14) NOT NULL,
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
                            degree_severity VARCHAR(255) NOT NULL,
                            symptons VARCHAR(255) NOT NULL,
                            date_symptons TIMESTAMP NOT NULL,
                            continuos_medicine VARCHAR(255),
                            Allergies VARCHAR(255),
                            emergency_id BIGINT,
                            FOREIGN KEY (emergency_id) REFERENCES emergencies(id)
                        )";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }
}
