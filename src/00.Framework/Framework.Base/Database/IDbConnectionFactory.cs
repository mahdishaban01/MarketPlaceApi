using System.Data;

namespace Framework.Base.Database;

public interface IDbConnectionFactory
{
    IDbConnection CreateDbConnection(string connectionName);
}