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

//        builder.HasMany(t => t.Admins).WithOne().HasForeignKey(t => t.OrgId).OnDelete(DeleteBehavior.NoAction); 
//        builder.HasMany(t => t.Contracts).WithOne().HasForeignKey(t => t.OrgId);
        builder.HasMany(t => t.Employees).WithOne().HasForeignKey(t => t.OrgId);

        builder.HasOne(t => t.MailAddress).WithMany().HasForeignKey(t => t.MailAddressId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(t => t.JureAddress).WithMany().HasForeignKey(t => t.JureAddressId).OnDelete(DeleteBehavior.NoAction);

    }
}
