using Contracts.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityConfigurations.Orgs;

public class OrgConfiguration : IEntityTypeConfiguration<Org>
{
    public void Configure(EntityTypeBuilder<Org> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name).HasMaxLength(250).IsRequired();
        builder.Property(t => t.ShortName).HasMaxLength(200).IsRequired();
        builder.Property(t => t.ViewName).HasMaxLength(100).IsRequired();

        builder.Property(t => t.Phone).HasMaxLength(100).IsRequired();
        builder.Property(t => t.WWW).HasMaxLength(100).IsRequired();
        builder.Property(t => t.EMail).HasMaxLength(100).IsRequired();

        builder.HasOne(t => t.Ownership).WithMany().HasForeignKey(t => t.OwnershipId);

        builder.HasMany(t => t.Employees).WithOne().HasForeignKey(t => t.OrgId);

//        builder.HasOne(t => t.MailAddress).WithMany(t => t.Orgs).HasForeignKey(t => t.MailAddressId);
//        builder.HasOne(t => t.JureAddress).WithMany(t => t.Orgs).HasForeignKey(t => t.JureAddressId);

    }
}
