// <copyright file="SchoolEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Data;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;

/// <inheritdoc/>
internal class SchoolEntityTypeConfiguration : IEntityTypeConfiguration<School>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.ToTable("schools");

        builder
            .Property(s => s.Id)
            .HasColumnName("id");

        builder
            .Property(s => s.Name)
            .HasColumnName("name");

        builder
           .HasMany(s => s.Courses)
           .WithOne(c => c.School)
           .HasForeignKey(c => c.SchoolId);
    }
}
