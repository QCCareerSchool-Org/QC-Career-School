// <copyright file="CourseEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace SC.Data;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;

/// <inheritdoc/>
public class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("courses");

        builder
            .Property(c => c.Id)
            .HasColumnName("id");

        builder
            .Property(c => c.SchoolId)
            .HasColumnName("school_id");

        builder
            .Property(c => c.Code)
            .HasColumnName("code")
            .HasColumnType("CHAR")
            .HasMaxLength(2);

        builder
            .Property(c => c.Version)
            .HasColumnName("version");

        builder
            .Property(c => c.StudentTypeType)
            .HasColumnName("student_type")
            .HasMaxLength(50);

        builder
            .Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(50);

        builder
            .Property(c => c.CourseGuide)
            .HasColumnName("course_guide");

        builder
            .Property(c => c.QuizzesEnabled)
            .HasColumnName("quizzes_enabled");

        builder
            .Property(c => c.NoTutor)
            .HasColumnName("no_tutor");

        builder
            .Property(c => c.UnitType)
            .HasColumnName("unit_type");

        builder
            .Property(c => c.Enabled)
            .HasColumnName("enabled");

        builder
            .Property(c => c.Order)
            .HasColumnName("order");

        builder
            .Property(c => c.UnitsEnabled)
            .HasColumnName("new_units_enabled");

        builder
            .Property(c => c.EntityVersion)
            .HasColumnName("entity_version");

        builder
           .HasMany(c => c.Enrollments)
           .WithOne(e => e.Course)
           .HasForeignKey(e => e.CourseId);
    }
}