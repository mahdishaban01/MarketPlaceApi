using Framework.Base.Constants;
using Framework.Base.Database;
using System.Data;

namespace MarketPlace.Infra.Data.Sql.Common;

public class MarketPlaceDbConnection(IDbConnectionFactory dbConnectionFactory)
{
    public IDbConnection DbConnection { get; } = dbConnectionFactory.CreateDbConnection(DatabaseConstants.MarketPlaceDatabase);
}