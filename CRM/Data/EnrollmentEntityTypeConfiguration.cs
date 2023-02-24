// <copyright file="EnrollmentEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Data;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;

/// <inheritdoc/>
internal class EnrollmentEntityTypeConfiguration : IEntityTypeConfiguration<Enrollment>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.ToTable("enrollments");

        builder
            .Property(e => e.Id)
            .HasColumnName("id");

        builder
            .Property(e => e.StudentId)
            .HasColumnName("student_id");

        builder
            .Property(e => e.CourseId)
            .HasColumnName("course_id");

        builder
            .Property(e => e.EnrollmentDate)
            .HasColumnName("enrollment_date");

        builder
            .Property(e => e.CurrencyId)
            .HasColumnName("currency_id");

        builder
            .Property(e => e.Cost)
            .HasColumnName("cost")
            .HasPrecision(10, 2);

        builder
            .Property(e => e.Discount)
            .HasColumnName("discount")
            .HasPrecision(10, 2);

        builder
            .HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId);

        builder
            .HasMany(e => e.Transactions)
            .WithOne(t => t.Enrollment)
            .HasForeignKey(t => t.EnrollmentId);

        builder
           .HasMany(e => e.TaxReceipts)
           .WithOne(t => t.Enrollment)
           .HasForeignKey(t => t.EnrollmentId);
    }
}
