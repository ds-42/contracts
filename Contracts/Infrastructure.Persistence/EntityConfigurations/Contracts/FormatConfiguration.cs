﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Contracts.Domain;

namespace Infrastructure.Persistence.EntityConfigurations.Contracts;

public class FormatConfiguration : IEntityTypeConfiguration<Format>
{
    public void Configure(EntityTypeBuilder<Format> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name).HasMaxLength(200).IsRequired();

        builder.Navigation(t => t.FormatType).AutoInclude();

        builder.HasOne(t => t.Org).WithMany().HasForeignKey(t => t.OrgId).OnDelete(DeleteBehavior.NoAction); 
        builder.HasOne(t => t.FormatType).WithMany().HasForeignKey(t => t.FormatTypeId);
    }
}

