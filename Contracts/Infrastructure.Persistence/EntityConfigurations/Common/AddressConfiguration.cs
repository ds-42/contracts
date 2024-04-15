using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Contracts.Domain;

namespace Infrastructure.Persistence.EntityConfigurations.Common;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Note).HasMaxLength(200).IsRequired();

//        builder.HasMany(t => t.Orgs).WithOne(t => t.JureAddress).HasForeignKey(t => t.JureAddressId);
//        builder.HasMany(t => t.Orgs).WithOne(t => t.MailAddress).HasForeignKey(t => t.MailAddressId);
    }
}
