using System.Data;

namespace SaudeSemFronteiras.Common.Factory.Interfaces;
public interface IDatabaseFactory
{
    public IDbConnection Connection { get; }
    public IDbTransaction? Transaction { get; }
    void Begin();
    void Commit();
    void Rollback();
}
