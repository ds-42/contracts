using Core.Application.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal sealed class DatabaseMigrator : IDatabaseMigrator
{
    private readonly DatabaseContext _dbContext;

    public DatabaseMigrator(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task MigrateAsync(CancellationToken cancellationToken)
    {
        return _dbContext.Database.MigrateAsync(cancellationToken);
    }

    public void Migrate()
    {
        _dbContext.Database.Migrate();
    }

    public IEnumerable<string> GetPendingMigrations()
    {
        return _dbContext.Database.GetPendingMigrations();
    }
}