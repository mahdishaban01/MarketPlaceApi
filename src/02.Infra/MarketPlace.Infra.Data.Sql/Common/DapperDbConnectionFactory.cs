using Framework.Base.Database;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MarketPlace.Infra.Data.Sql.Common;

public class DapperDbConnectionFactory(IDictionary<string, string> connectionDict) : IDbConnectionFactory
{
    public IDbConnection CreateDbConnection(string connectionName)
    {
        if (connectionDict.TryGetValue(connectionName, out var connectionString))
            return new SqlConnection(connectionString);

        throw new ArgumentNullException();
    }
}