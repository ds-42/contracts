using Contracts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations.Contracts;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Number).HasMaxLength(20).IsRequired();
        builder.Property(t => t.Description).HasMaxLength(200).IsRequired();

        builder.Property(t => t.PlannedPrice).HasPrecision(18, 6);

        builder.HasOne(t => t.Format).WithMany().HasForeignKey(t => t.FormatId);
        builder.HasOne(t => t.Currency).WithMany().HasForeignKey(t => t.CurrencyId);

        builder
            .HasMany(t => t.Documents)
            .WithOne()
            .HasForeignKey(t => t.GroupId);

        builder
            .HasMany(e => e.Orgs)
            .WithOne(e => e.Contract)
            .HasForeignKey(e => e.ContractId);
    }
}
