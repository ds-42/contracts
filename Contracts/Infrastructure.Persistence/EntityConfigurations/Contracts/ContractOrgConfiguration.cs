using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Contracts.Domain;

namespace Infrastructure.Persistence.EntityConfigurations.Contracts;

public class ContractOrgConfiguration : IEntityTypeConfiguration<ContractOrg>
{
    public void Configure(EntityTypeBuilder<ContractOrg> builder)
    {
        builder.HasKey(t => new { t.OrgId, t.ContractId });

        builder.HasOne(e => e.Org)
            .WithMany(e => e.Contracts)
            .HasForeignKey(e => e.OrgId);

        builder.HasOne(e => e.Contract)
            .WithMany(e => e.Orgs)
            .HasForeignKey(e => e.ContractId);
    }
}
