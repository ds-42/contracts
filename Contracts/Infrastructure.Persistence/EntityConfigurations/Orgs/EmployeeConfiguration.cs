using Contracts.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Contracts.Domain.Enums;

namespace Infrastructure.Persistence.EntityConfigurations.Orgs;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Surname).HasMaxLength(100).IsRequired();
        builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
        builder.Property(t => t.Patronymic).HasMaxLength(100).IsRequired();
        builder.Property(t => t.PostName).HasMaxLength(200).IsRequired();
        builder.Property(t => t.Operating).HasMaxLength(200).IsRequired();

        builder.Property(t => t.PhoneWork).HasMaxLength(100).IsRequired();
        builder.Property(t => t.PhoneMobile).HasMaxLength(100).IsRequired();
        builder.Property(t => t.WWW).HasMaxLength(100).IsRequired();
        builder.Property(t => t.EMail).HasMaxLength(100).IsRequired();

        builder.HasOne(t => t.User).WithMany().HasForeignKey(t => t.UserId);
    }
}
