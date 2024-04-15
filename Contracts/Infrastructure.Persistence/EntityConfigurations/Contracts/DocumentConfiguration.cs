using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Contracts.Domain;

namespace Infrastructure.Persistence.EntityConfigurations.Contracts;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Number).HasMaxLength(20).IsRequired();
        builder.Property(t => t.Title).HasMaxLength(200).IsRequired();

        builder.HasOne(t => t.File).WithMany().HasForeignKey(t => t.FileId);
    }
}
