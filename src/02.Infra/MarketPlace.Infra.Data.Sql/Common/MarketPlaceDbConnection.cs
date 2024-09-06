using Framework.Base.Constants;

namespace MarketPlace.Infra.Data.Sql.Common;

public class MarketPlaceDbConnection(IDbConnectionFactory dbConnectionFactory)
{
    public IDbConnection DbConnection { get; } = dbConnectionFactory.CreateDbConnection(DatabaseConstants.MarketPlaceDatabase);
}