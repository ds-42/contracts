using Core.Application.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal sealed class DatabaseMigrator : IDatabaseMigrator
{
    private readonly DatabaseContext _dbApplicationDbContext;

    public DatabaseMigrator(DatabaseContext dbApplicationDbContext)
    {
        _dbApplicationDbContext = dbApplicationDbContext;
    }

    public Task MigrateAsync(CancellationToken cancellationToken)
    {
        return _dbApplicationDbContext.Database.MigrateAsync(cancellationToken);
    }

    public void Migrate()
    {
        _dbApplicationDbContext.Database.Migrate();
    }

    public IEnumerable<string> GetPendingMigrations()
    {
        return _dbApplicationDbContext.Database.GetPendingMigrations();
    }
}