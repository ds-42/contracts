using Auth.Domain;
using Contracts.Domain;
using Core.Users.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using File = Contracts.Domain.File;

namespace Infrastructure.Persistence;

public class DatabaseContext : DbContext
{
    #region Users

    internal DbSet<User> Users { get; } = default!;

    #endregion

    #region Auth

    internal DbSet<RefreshToken> RefreshTokens { get; } = default!;

    #endregion

    #region Contracts

    internal DbSet<Contract> Contracts { get; } = default!;
    internal DbSet<Document> Documents { get; } = default!;
    internal DbSet<Format> Formats { get; } = default!;
    internal DbSet<FormatType> FormatTypes { get; } = default!;

    #endregion

    #region Orgs

    internal DbSet<ContractOrg> ContractOrgs { get; } = default!;
    internal DbSet<Employee> Employees { get; } = default!;
    internal DbSet<Org> Orgs { get; } = default!;
    internal DbSet<Ownership> Ownerships { get; } = default!;

    #endregion

    #region Common

    internal DbSet<Address> Addresses { get; } = default!;
    internal DbSet<Currency> Currencies { get; } = default!;
    internal DbSet<File> Files { get; } = default!;

    #endregion

    #region Ef

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    #endregion
}
