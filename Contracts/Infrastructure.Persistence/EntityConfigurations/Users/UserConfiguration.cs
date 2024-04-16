using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Users.Domain;

namespace Infrastructure.Persistence.EntityConfigurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Login).HasMaxLength(100).IsRequired();
        builder.Property(t => t.Password).HasMaxLength(100).IsRequired();
    }
}
