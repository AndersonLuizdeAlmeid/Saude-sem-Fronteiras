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
                           title as Title,
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
                           title as Title,
                           description as Description, 
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
}
