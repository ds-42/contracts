﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using File = Contracts.Domain.File;

namespace Infrastructure.Persistence.EntityConfigurations.Common;

public class FileConfiguration : IEntityTypeConfiguration<File>
{
    public void Configure(EntityTypeBuilder<File> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.FileName).HasMaxLength(200).IsRequired();
        builder.HasOne(t => t.User).WithMany().HasForeignKey(t => t.UserId);
    }
}

