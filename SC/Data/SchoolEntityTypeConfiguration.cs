// <copyright file="SchoolEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace SC.Data;

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
            .Property(c => c.Id)
            .HasColumnName("id");

        builder
            .Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(50);

        builder
            .HasMany(s => s.Courses)
            .WithOne(c => c.School)
            .HasForeignKey(c => c.SchoolId);
    }
}
