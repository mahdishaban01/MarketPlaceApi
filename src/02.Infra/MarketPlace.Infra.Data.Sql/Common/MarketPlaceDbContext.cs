using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Data.Sql.Common;

public class MarketPlaceDbContext(DbContextOptions<MarketPlaceDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly,
            x => x.Namespace != null && x.Namespace.StartsWith("MarketPlace.Infra.Data.Sql"));
    }
}