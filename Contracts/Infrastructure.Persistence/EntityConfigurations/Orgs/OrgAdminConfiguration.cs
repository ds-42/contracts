using Contracts.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityConfigurations.Orgs;

public class OrgAdminConfiguration : IEntityTypeConfiguration<OrgAdmin>
{
    public void Configure(EntityTypeBuilder<OrgAdmin> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.Org).WithMany().HasForeignKey(t => t.OrgId);
        builder.HasOne(t => t.User).WithMany().HasForeignKey(t => t.UserId);
    }
}

