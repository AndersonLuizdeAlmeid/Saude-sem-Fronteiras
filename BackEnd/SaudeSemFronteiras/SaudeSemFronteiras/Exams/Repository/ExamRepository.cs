using Dapper;
using SaudeSemFronteiras.Application.Exams.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Exams.Repository;
public class ExamRepository(IDatabaseFactory LocalDatabase) : IExamRepository
{
    public async Task<Exam?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           title as Title,
                           description as Description, 
                           date_exam as DateExam,
                           local_exam as LocalExam,
                           results as Results,
                           comments as Comments
                      from exams
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Exam>(command);
    }

    public async Task Insert(Exam exam, CancellationToken cancellationToken)
    {
        var sql = @"insert into exams(title, description, date_exam, local_exam, results, comments) 
                              values (@Title, @Description, @DateExam, @LocalExam, @Results, @Comments)";
        var command = new CommandDefinition(sql, exam, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Exam exam, CancellationToken cancellationToken)
    {
        var sql = @"update exams
                       set title = @Title,
                           description = @Description, 
                           date_exam = @DateExam,
                           local_exam = @LocalExam,
                           results = @Results,
                           comments = @Comments
                     where id = @Id";

        var command = new CommandDefinition(sql, exam, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
