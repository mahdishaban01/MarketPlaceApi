using Framework.Base.UnitOfWorks;

namespace MarketPlace.Infra.Data.Sql.Common;

public class UnitOfWork(MarketPlaceDbContext marketPlaceDbContext) : IUnitOfWork
{
    public async Task Commit() => await marketPlaceDbContext.SaveChangesAsync();
}