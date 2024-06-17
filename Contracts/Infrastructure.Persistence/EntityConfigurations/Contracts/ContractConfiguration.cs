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

        builder.Navigation(t => t.Currency).AutoInclude();
        builder.Navigation(t => t.Format).AutoInclude();

        builder.HasOne(t => t.Currency).WithMany().HasForeignKey(t => t.CurrencyId);
        builder.HasOne(t => t.Format).WithMany().HasForeignKey(t => t.FormatId);
        builder.HasOne(t => t.Org).WithMany().HasForeignKey(t => t.OrgId);

    }
}
