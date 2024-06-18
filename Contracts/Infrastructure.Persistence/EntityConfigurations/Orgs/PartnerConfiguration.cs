using Contracts.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityConfigurations.Orgs;

public class PartnerConfiguration : IEntityTypeConfiguration<Partner>
{
    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Navigation(t => t.PartnerOrg).AutoInclude();

        builder.Property(t => t.ViewName).HasMaxLength(100).IsRequired();
        builder.HasOne(t => t.Org).WithMany().HasForeignKey(t => t.OrgId).OnDelete(DeleteBehavior.NoAction); 
        builder.HasOne(t => t.PartnerOrg).WithMany().HasForeignKey(t => t.PartnerId).OnDelete(DeleteBehavior.NoAction); 
    }
}
