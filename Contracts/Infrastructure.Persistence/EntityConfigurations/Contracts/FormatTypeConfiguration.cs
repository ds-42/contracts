using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Contracts.Domain;

namespace Infrastructure.Persistence.EntityConfigurations.Contracts;

public class FormatTypeConfiguration : IEntityTypeConfiguration<FormatType>
{
    public void Configure(EntityTypeBuilder<FormatType> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
    }
}
