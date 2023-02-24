// <copyright file="EnrollmentEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace SC.Data;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;
using System.Reflection.Emit;

/// <inheritdoc/>
internal class EnrollmentEntityTypeConfiguration : IEntityTypeConfiguration<Enrollment>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.ToTable("students");

        builder
            .Property(e => e.Id)
            .HasColumnName("id");

        builder
            .Property(e => e.StudentId)
            .HasColumnName("account_id");

        builder
            .Property(e => e.CourseId)
            .HasColumnName("course_id");

        builder
            .HasOne(e => e.Student)
            .WithMany()
            .HasForeignKey(e => e.StudentId);

        builder
            .HasOne(e => e.Course)
            .WithMany()
            .HasForeignKey(e => e.CourseId);
    }
}
