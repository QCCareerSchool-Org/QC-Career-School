// <copyright file="CourseEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Data;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;

/// <inheritdoc/>
internal class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("courses");

        builder
            .Property(c => c.Id)
            .HasColumnName("id");

        builder
            .Property(c => c.Code)
            .HasColumnName("code")
            .HasColumnType("CHAR")
            .HasMaxLength(2);

        builder
            .Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(255);

        builder
            .Property(c => c.Prefix)
            .HasColumnName("prefix")
            .HasColumnType("CHAR")
            .HasMaxLength(2);

        builder
            .Property(c => c.SchoolId)
            .HasColumnName("school_id");

        builder
           .HasMany(c => c.Enrollments)
           .WithOne(e => e.Course)
           .HasForeignKey(e => e.CourseId);
    }
}